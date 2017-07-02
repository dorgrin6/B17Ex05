namespace UserInterface
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class GameLine
    {
        private const string k_AcceptText = "-->>";

        private const ushort k_SpaceOffset = 10;

        private readonly GuessesButtonsList r_Guesses;

        private readonly Button r_AcceptButton;

        private readonly ResultsButtonsList r_Results;

        public enum eAcceptButtonSize
        {
            Width = 50,

            Height = 20
        }

        public GameLine(Point i_Location)
        {
            r_Guesses = new GuessesButtonsList(i_Location);
            foreach (Button btn in r_Guesses.List)
            {
                btn.Click += new EventHandler(buttonColor_Click);
            }

            r_AcceptButton = new Button();
            r_AcceptButton.Text = k_AcceptText;
            r_AcceptButton.Size = new Size((int)eAcceptButtonSize.Width, (int)eAcceptButtonSize.Height);
            r_AcceptButton.Enabled = false;

            i_Location.X += r_Guesses.GetLengthX();
            i_Location.Y += r_Guesses.GetLengthY() / 2;
            r_AcceptButton.Location = i_Location;

            i_Location.X += (int)eAcceptButtonSize.Width + k_SpaceOffset;
            i_Location.Y -= (int)eAcceptButtonSize.Height / 2;

            r_Results = new ResultsButtonsList(i_Location);
        }

        public GuessesButtonsList GuessButtons
        {
            get
            {
                return r_Guesses;
            }
        }

        public Button AcceptButton
        {
            get
            {
                return r_AcceptButton;
            }
        }

        public ResultsButtonsList ResultButtons
        {
            get
            {
                return r_Results;
            }
        }

        public int GetLengthY()
        {
            return r_Guesses.GetLengthY();
        }

        public void EnableLine(bool i_IsEnabled)
        {
            r_Guesses.EnableButtons(i_IsEnabled);
            if (!i_IsEnabled)
            {
                r_AcceptButton.Enabled = i_IsEnabled;
            }
        }

        public void buttonColor_Click(object i_Sender, EventArgs i_Event)
        {
            if (!r_AcceptButton.Enabled && r_Guesses.LeftToSelectColor == 0)
            {
                r_AcceptButton.Enabled = true;
            }
        }

        public void ShowResults(ushort i_ExistRightPlace, ushort i_ExistWrongPlace)
        {
            r_Results.ShowResults(i_ExistRightPlace, i_ExistWrongPlace);
        }
    }
}
