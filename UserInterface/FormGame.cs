namespace UserInterface
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;
    using System.Collections.Generic;
    using B17_Ex02;

    public class FormGame : Form
    {
        private readonly FormStart m_FormStart = new FormStart();

        private readonly GameLogic m_GameLogic = new GameLogic();

        private GuessesButtonsList m_GameGoal;

        private List<GameLine> m_GameLine;

        private ushort m_CurrentLine = 0;

        private const ushort k_SpaceOffset = 30;

        public FormGame()
        {
            this.Text = FormStart.k_FormText;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
            this.Size = new Size((int)eDefaultFormSize.Width, (int)eDefaultFormSize.Height);
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        private enum eFormStartLocation
        {
            Left = 20,

            Top = 20
        }

        private enum eDefaultFormSize
        {
            Width = 380,

            Height = 800
        }

        public void Run()
        {
            m_FormStart.ShowDialog();
            if (m_FormStart.DialogResult != DialogResult.Cancel)
            {
                buildGameBoard();
                this.ShowDialog();
            }
        }

        private void addLineToForm(GameLine i_Line)
        {
            addButtonsToForm(i_Line.GuessButtons);
            this.Controls.Add(i_Line.AcceptButton);
            addButtonsToForm(i_Line.ResultButtons);
        }

        private void addButtonsToForm(ButtonsList i_ButtonsList)
        {
            //TODO: we need a smart way to encapsulate the GuessSize=4
            for (int i = 0; i < 4; i++)
            {
                this.Controls.Add(i_ButtonsList[i]);
            }
        }

        private void buildGameBoard()
        {
            Point location = new Point(20, 20);
            const bool isEnabled = true;

            m_GameGoal = new GuessesButtonsList(location);
            m_GameGoal.DarkButtons();

            location.Y += m_GameGoal.GetLengthY() + 30;
            addButtonsToForm(m_GameGoal);

            m_GameLine = new List<GameLine>(m_FormStart.GuessAmountCount);

            // TODO: we should avoid using for loop
            for (int i = 0; i < m_FormStart.GuessAmountCount; i++)
            {
                m_GameLine.Add(new GameLine(location));
                m_GameLine[i].AcceptButton.Click += new EventHandler(button_Click);
                m_GameLine[i].EnableLine(!isEnabled);
                addLineToForm(m_GameLine[i]);
                location.Y += m_GameLine[i].GetLengthY();
            }

            m_GameLine[0].EnableLine(isEnabled);
            buildFormBorder();
        }

        private void buildFormBorder()
        {
            int height = 0;
            int width = 0;
            int linesAmount = m_FormStart.GuessAmountCount + 1; // including the game's board and the game's goal
            int lineHeight = m_GameGoal.GetLengthY(); // includind the line's height and the space offset

            height = (int)eFormStartLocation.Top + lineHeight * linesAmount + k_SpaceOffset;
            width = (int)eDefaultFormSize.Width;

            this.ClientSize = new Size(width, height);
        }

        private void button_Click(object i_Sender, EventArgs i_Evet)
        {
            List<Color> colors;
            string letters;
            const bool isEnabled = true;

            if (m_GameLine[m_CurrentLine].isGuessLegal())
            {
                colors = m_GameLine[m_CurrentLine].GuessButtons.GetColorsList();
                letters = ColorUtilities.ConvertColorsToString(colors);
                if (m_GameLogic.HasDuplicateLetters(letters))
                {
                    // print message "duplictae colors"
                }
                else
                {
                    // we need to enter the input to the logic, and compute results

                    m_GameLine[m_CurrentLine].EnableLine(!isEnabled);
                    m_CurrentLine++;
                    if (m_CurrentLine != m_GameLine.Count)
                    {
                        m_GameLine[m_CurrentLine].EnableLine(isEnabled);
                    }
                    
                }
            }
            else
            {
                //print message "
            }
            

        }
    }
}