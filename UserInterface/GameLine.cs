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

        /*TODO: once the accept button is on we neeed to prefrom the following:
            1) check if all colors in that line were entered , otherwise print an error message "Choose all colors for guess"
            2) if all colors were entered we need to check the result and show it in the ResultButtonsList
            3) if all results correct we print a message "you win"
            4) else, if number of guessing lines ended then print message "you lost"
            5) else, enable next line of guessing (so player can choose colors)
        */
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
        
        public bool isGuessLegal()
        {
            bool isGuessLegal = true;

            if (!m_Guesses.isAllColorsSelected())
            {
                isGuessLegal = false;
            }

            return isGuessLegal;
        }
       
        public void EnableLine(bool i_IsEnabled)
        {
            m_Guesses.EnableButtons(i_IsEnabled);
            m_AcceptButton.Enabled = i_IsEnabled;
        }
    }
}
