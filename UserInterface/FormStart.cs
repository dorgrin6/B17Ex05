namespace UserInterface
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormStart : Form
    {
        public const string k_FormText = "Bool Pgia";

        public const string k_StartText = "Start";

        private const int k_MaxNumOfChances = 8;

        private const int k_MinNumOfChances = 4;

        private const string k_NumOfChangesText = "Number of chances: {0}";

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

        private enum eButtonStartSize
        {
            Width = 100,

            Height = 20
        }

        private enum eFormSize
        {
            Width = 380,

            Height = 190
        }

        public ushort NumOfChancesCount
        {
            get
            {
                return m_NumOfChancesCount;
            }
        }

        protected override void OnLoad(EventArgs i_Event)
        {
            base.OnLoad(i_Event);

            initializeComponent();
        }

        private void button_Click(object i_Sender, EventArgs i_Event)
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
                m_ButtonStart,
                k_StartText,
                new Point((int)eButtonStartLocation.Left, (int)eButtonStartLocation.Top),
                new Size((int)eButtonStartSize.Width, (int)eButtonStartSize.Height));

            initailizeButton(
                m_ButtonNumOfChances,
                string.Format(k_NumOfChangesText, m_NumOfChancesCount),
                new Point(
                    formCenterLeft - (int)eButtonNumOfChancesOffset.Left,
                    m_ButtonStart.Top - (int)eButtonNumOfChancesOffset.Top),
                new Size((int)eButtonNumOfChangesSize.Width, (int)eButtonNumOfChangesSize.Height));

            /*
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
        */
        }

        private void startGame()
        {
            this.Close();
        }
    }
}