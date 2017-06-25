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
            m_AcceptButton = new Button();

            m_AcceptButton.Text = k_AcceptText;
            m_AcceptButton.Size = new Size((int)eAcceptButtonSize.Width, (int)eAcceptButtonSize.Height);

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
    }
}
