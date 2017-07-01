namespace UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    using GameLogic;

    public class FormGame : Form
    {
        private const string k_MessageErrorDuplicateColors = "Error. Dont use same color in a guess.";

        private const string k_MessageLost = "Sorry. You lost the game.";

        private const string k_MessageWin = "Congratulations! You won!";

        private const ushort k_SpaceOffset = 30;

        private readonly FormStart r_FormStart = new FormStart();

        private readonly GameLogic r_GameLogic = new GameLogic();

        private ushort m_CurrentLine = 0;

        private GuessesButtonsList m_GameGoal;

        private List<GameLine> m_GameLines;

        public FormGame()
        {
            this.Text = FormStart.k_FormText;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Size = new Size((int)eDefaultFormSize.Width, (int)eDefaultFormSize.Height);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private enum eDefaultFormSize
        {
            Width = 380,

            Height = 800
        }

        private enum eFormStartLocation
        {
            Left = 20,

            Top = 20
        }

        public void Run()
        {
            r_FormStart.ShowDialog();
            if (r_FormStart.DialogResult != DialogResult.Cancel)
            {
                r_GameLogic.UserGuessesAmount = r_FormStart.GuessAmountCount;
                r_GameLogic.InitiateGame();

                buildGameBoard();
                this.ShowDialog();
            }
        }

        private void acceptUserGuess(string i_UserGuess)
        {
            ushort existRightPlace;
            ushort existWrongPlace;
            const bool isEnabled = true;

            insertGuessToBoard(m_CurrentLine, i_UserGuess);
            existRightPlace = r_GameLogic.Board[m_CurrentLine].ExistRightPlaceResult;
            existWrongPlace = r_GameLogic.Board[m_CurrentLine].ExistWrongPlaceResult;
            m_GameLines[m_CurrentLine].ShowResults(existRightPlace, existWrongPlace);
            m_GameLines[m_CurrentLine].EnableLine(!isEnabled);

            if (r_GameLogic.IsWinningGuess(m_CurrentLine))
            {
                m_GameGoal.CopyButtonsColors(m_GameLines[m_CurrentLine].GuessButtons.List);
                MessageBox.Show(k_MessageWin);
            }
            else
            {
                m_CurrentLine++;
                activateNextLine();
            }
        }

        private void activateNextLine()
        {
            const bool v_IsEnabled = true;

            if (m_CurrentLine != m_GameLines.Count)
            {
                m_GameLines[m_CurrentLine].EnableLine(v_IsEnabled);
            }
            else
            {
                MessageBox.Show(k_MessageLost);
            }
        }

        private void addButtonsToForm(ButtonsList i_ButtonsList)
        {
            foreach (Button btn in i_ButtonsList.List)
            {
                this.Controls.Add(btn);
            }
        }

        private void addLineToForm(GameLine i_Line)
        {
            addButtonsToForm(i_Line.GuessButtons);
            this.Controls.Add(i_Line.AcceptButton);
            addButtonsToForm(i_Line.ResultButtons);
        }

        private void buildFormBorder()
        {
            int height = 0;
            int width = 0;
            int linesAmount = r_FormStart.GuessAmountCount + 1; // including the game's board and the game's goal
            int lineHeight = m_GameGoal.GetLengthY(); // includind the line's height and the space offset

            height = (int)eFormStartLocation.Top + lineHeight * linesAmount + k_SpaceOffset;
            width = (int)eDefaultFormSize.Width;

            this.ClientSize = new Size(width, height);
        }

        private void buildGameBoard()
        {
            Point location = new Point(20, 20);
            const bool isEnabled = true;

            //creates the game goal in the upper part of the form
            createGameGoal(ref location);

            //creates the game lines
            m_GameLines = new List<GameLine>(r_FormStart.GuessAmountCount);
            for (int i = 0; i < r_FormStart.GuessAmountCount; i++)
            {
                if (i == 0)
                {
                    createGameLine(ref location, isEnabled);
                }
                else
                {
                    createGameLine(ref location, !isEnabled);
                }
            }

            buildFormBorder();
        }

        private void buttonAccept_Click(object i_Sender, EventArgs i_Evet)
        {
            List<Color> colors;
            string letters;

            colors = m_GameLines[m_CurrentLine].GuessButtons.GetColorsList();
            letters = ColorUtilities.ConvertColorsToLetters(colors);
            if (r_GameLogic.HasDuplicateLetters(letters))
            {
                MessageBox.Show(k_MessageErrorDuplicateColors);
            }
            else
            {
                acceptUserGuess(letters);
            }
        }

        private void createGameGoal(ref Point io_Location)
        {
            m_GameGoal = new GuessesButtonsList(io_Location);
            m_GameGoal.DarkButtons();
            io_Location.Y += m_GameGoal.GetLengthY() + k_SpaceOffset;
            addButtonsToForm(m_GameGoal);
        }

        private void createGameLine(ref Point io_Location, bool i_isEnabled)
        {
            GameLine newGameLine;

            newGameLine = new GameLine(io_Location);
            newGameLine.AcceptButton.Click += new EventHandler(buttonAccept_Click);
            newGameLine.EnableLine(i_isEnabled);
            m_GameLines.Add(newGameLine);
            addLineToForm(newGameLine);
            io_Location.Y += newGameLine.GetLengthY();
        }

        private void insertGuessToBoard(int i_BoardIndex, string i_UserGuess)
        {
            BoardLine lineToInsert = r_GameLogic.Board[i_BoardIndex];

            for (int i = 0; i < i_UserGuess.Length; i++)
            {
                lineToInsert.UserGuess[i] = i_UserGuess[i];
            }

            r_GameLogic.SetExistingValuesInGuess(i_BoardIndex);
        }
    }
}