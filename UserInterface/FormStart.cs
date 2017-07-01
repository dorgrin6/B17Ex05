namespace UserInterface
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormStart : Form
    {
        public const string k_FormText = "Bool Pgia";

        public const string k_StartText = "Start";

        private const int k_MaxNumOfGuesses = 10;

        private const int k_MinNumOfGuesses = 4;

        private const string k_NumOfGuessesText = "Number of chances: {0}";

        private readonly Button r_ButtonNumOfGuesses = new Button();

        private readonly Button r_ButtonStart = new Button();

        private ushort m_GuessAmountCount = k_MinNumOfGuesses;

        public FormStart()
        {
            this.Text = k_FormText;
            this.Size = new Size((int)eFormSize.Width, (int)eFormSize.Height);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private enum eButtonNumOfGuessesOffset
        {
            Left = 600,

            Top = 50
        }

        private enum eButtonNumOfGuessesSize
        {
            Width = 200,

            Height = 20
        }

        private enum eButtonStartLocation
        {
            Left = 240,

            Top = 80
        }

        private enum eButtonStartSize
        {
            Width = 100,

            Height = 20
        }

        private enum eFormSize
        {
            Width = 380,

            Height = 160
        }

        public ushort GuessAmountCount
        {
            get
            {
                return m_GuessAmountCount;
            }
        }

        protected override void OnLoad(EventArgs i_Event)
        {
            base.OnLoad(i_Event);

            initializeComponent();
        }

        private void button_Click(object i_Sender, EventArgs i_Event)
        {
            if (i_Sender == r_ButtonNumOfGuesses)
            {
                increaseGuessesIfLowerThanMax();
            }
            else if (i_Sender == r_ButtonStart)
            {
                startGame();
            }
        }

        private void increaseGuessesIfLowerThanMax()
        {
            if (m_GuessAmountCount < k_MaxNumOfGuesses)
            {
                m_GuessAmountCount++;
            }
            else
            {
                m_GuessAmountCount = k_MinNumOfGuesses;
            }

            r_ButtonNumOfGuesses.Text = string.Format(k_NumOfGuessesText, m_GuessAmountCount);
        }

        private void initailizeButton(Button i_Button, string i_Text, Point i_Location, Size i_Size)
        {
            i_Button.Text = i_Text;
            this.Controls.Add(i_Button);
            i_Button.Location = i_Location;
            i_Button.Size = i_Size;
            i_Button.Click += new EventHandler(button_Click);
        }

        private void initializeComponent()
        {
            int formCenterLeft = (this.Left + this.Right) / 2;
            int formCenterTop = (this.Top + this.Bottom) / 2;

            initailizeButton(
                r_ButtonStart,
                k_StartText,
                new Point((int)eButtonStartLocation.Left, (int)eButtonStartLocation.Top),
                new Size((int)eButtonStartSize.Width, (int)eButtonStartSize.Height));

            initailizeButton(
                r_ButtonNumOfGuesses,
                string.Format(k_NumOfGuessesText, m_GuessAmountCount),
                new Point(
                    formCenterLeft - (int)eButtonNumOfGuessesOffset.Left,
                    r_ButtonStart.Top - (int)eButtonNumOfGuessesOffset.Top),
                new Size((int)eButtonNumOfGuessesSize.Width, (int)eButtonNumOfGuessesSize.Height));
        }

        private void startGame()
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}