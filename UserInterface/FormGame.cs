namespace UserInterface
{
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

            m_GameGoal = new GuessesButtonsList(location);
            location.Y += m_GameGoal.GetLengthY() + 30;
            addButtonsToForm(m_GameGoal);

            m_GameLine = new List<GameLine>(m_FormStart.GuessAmountCount);
            for (int i=0; i<m_FormStart.GuessAmountCount; i++)
            {
                m_GameLine.Add(new GameLine(location));
                addLineToForm(m_GameLine[i]);
                location.Y += m_GameLine[i].GetLengthY();
            }

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
    }
}