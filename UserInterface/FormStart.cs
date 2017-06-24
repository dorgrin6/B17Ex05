namespace UserInterface
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormStart : Form
    {
        private const int k_MaxNumOfChances = 8;

        private const int k_MinNumOfChances = 4;

        private const string k_NumOfChangesText = "Number of chances: {0}";

        public const string k_StartText = "Start";

        public const string k_FormText = "Bool Pgia";

        private readonly Button m_ButtonNumOfChances = new Button();

        private readonly Button m_ButtonStart = new Button();

        private ushort m_NumOfChancesCount = k_MinNumOfChances;

        public FormStart()
        {
            this.Text = k_FormText;
            this.Size = new Size((int)eFormSize.Width, (int)eFormSize.Height);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        }

        private enum eButtonNumOfChancesOffset
        {
            Left = 600,

            Top = 50
        }

        private enum eButtonNumOfChangesSize
        {
            Width = 200,

            Height = 20
        }

        private enum eButtonStartLocation
        {
            Left = 240,

            Top = 80
        }

        private enum eFormSize
        {
            Width = 380,

            Height = 190
        }

        protected override void OnLoad(EventArgs i_Event)
        {
            base.OnLoad(i_Event);

            initializeComponent();
        }

        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
        }

        private void button_Click(object i_Sender, EventArgs i_Evet)
        {
            if (i_Sender == m_ButtonNumOfChances)
            {
                increaseChancesIfLowerThanMax();
            }
            else if (i_Sender == m_ButtonStart)
            {
                startGame();
            }
        }

        private void increaseChancesIfLowerThanMax()
        {
            if (m_NumOfChancesCount < k_MaxNumOfChances)
            {
                m_NumOfChancesCount++;
                m_ButtonNumOfChances.Text = string.Format(k_NumOfChangesText, m_NumOfChancesCount);
            }
        }

        private void initializeComponent()
        {
            int formCenterLeft = (this.Left + this.Right) / 2;
            int formCenterTop = (this.Top + this.Bottom) / 2;

            m_ButtonStart.Text = k_StartText;
            this.Controls.Add(m_ButtonStart);
            m_ButtonStart.Location = new Point((int)eButtonStartLocation.Left, (int)eButtonStartLocation.Top);
            m_ButtonStart.Click += new EventHandler(button_Click);

            m_ButtonNumOfChances.Text = string.Format(k_NumOfChangesText, m_NumOfChancesCount);
            this.Controls.Add(m_ButtonNumOfChances);
            m_ButtonNumOfChances.Size = new Size(
                (int)eButtonNumOfChangesSize.Width,
                (int)eButtonNumOfChangesSize.Height);
            m_ButtonNumOfChances.Location = new Point(
                formCenterLeft - (int)eButtonNumOfChancesOffset.Left,
                m_ButtonStart.Top - (int)eButtonNumOfChancesOffset.Top);
            m_ButtonNumOfChances.Click += new EventHandler(button_Click);
        }

        private void startGame()
        {
            this.Close();
        }
    }
}