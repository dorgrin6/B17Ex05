using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UserInterface
{
    public class GameLine
    {
        private readonly GuessesButtonsList m_Guesses;

        private readonly Button m_AcceptButton;

        private readonly ResultsButtonsList m_Results;

        public const string k_AcceptText = "-->>";

        private const ushort k_SpaceOffset = 10;

        public enum eAcceptButtonSize
        {
            Width = 50,

            Height = 20
        }

        public GameLine(Point i_Location)
        {
            m_Guesses = new GuessesButtonsList(i_Location);
            foreach(Button btn in m_Guesses.List)
            {
                btn.Click += new EventHandler(buttonColor_Click);
            }

            m_AcceptButton = new Button();
            m_AcceptButton.Text = k_AcceptText;
            m_AcceptButton.Size = new Size((int)eAcceptButtonSize.Width, (int)eAcceptButtonSize.Height);
            m_AcceptButton.Enabled = false;

            i_Location.X += m_Guesses.GetLengthX();
            i_Location.Y += m_Guesses.GetLengthY() / 2;
            m_AcceptButton.Location = i_Location;

            i_Location.X += (int)eAcceptButtonSize.Width + k_SpaceOffset;
            i_Location.Y -= (int)eAcceptButtonSize.Height / 2;

            m_Results = new ResultsButtonsList(i_Location);
        }

        public GuessesButtonsList GuessButtons
        {
            get
            {
                return m_Guesses;
            }
        }

        public Button AcceptButton
        {
            get
            {
                return m_AcceptButton;
            }
        }

        public ResultsButtonsList ResultButtons
        {
            get
            {
                return m_Results;
            }
        }

        public int GetLengthY()
        {
            return m_Guesses.GetLengthY();
        }
       
        public void EnableLine(bool i_IsEnabled)
        {
            m_Guesses.EnableButtons(i_IsEnabled);
            if (!i_IsEnabled)
            {
                m_AcceptButton.Enabled = i_IsEnabled;
            }
        }

        public void buttonColor_Click(object i_Sender, EventArgs i_Event)
        {
            if (!m_AcceptButton.Enabled && m_Guesses.LeftToSelectColor == 0)
            {
                m_AcceptButton.Enabled = true;
            }
        }

        public void ShowResults(ushort i_ExistRightPlace, ushort i_ExistWrongPlace)
        {
            m_Results.ShowResults(i_ExistRightPlace, i_ExistWrongPlace);
        }
    }
}
