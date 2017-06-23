using System.Windows.Forms;

namespace UserInterface
{
    using System;
    using System.Drawing;

    public class StartForm : Form
    {
        private Button m_ButtonNumOfChances = new Button();

        private Button m_ButtonStart = new Button();

        private ushort m_NumOfChancesCount = 1;

        private const string m_FormText = "Bool Pgia";

        private enum eButtonNumOfChangesSize
        {
            width = 150,
            height = 20
        }

        private enum eFormSize
        {
            width = 350,
            height = 200
        }
        

        public StartForm()
        {
            this.Text = m_FormText;
            this.Size = new Size((int)eFormSize.width, (int) eFormSize.height);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.Fixed3D;
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

        private void initializeComponent()
        {
            int formCenterLeft = (this.Left + this.Right) / 2;
            int formCenterTop = (this.Top + this.Bottom) / 2;


            m_ButtonStart.Text = "Start";
            this.Controls.Add(m_ButtonStart);
            m_ButtonStart.Location = new Point(240, 120);
           // m_ButtonStart.Click += new EventHandler(button_Click);

            m_ButtonNumOfChances.Text = String.Format("Number of chances: {0}", m_NumOfChancesCount);
            this.Controls.Add(m_ButtonNumOfChances);
            m_ButtonNumOfChances.Size = new Size((int)eButtonNumOfChangesSize.width, (int)eButtonNumOfChangesSize.height);
            m_ButtonNumOfChances.Location = new Point(formCenterLeft - 600, m_ButtonStart.Top - 75);
            m_ButtonNumOfChances.Click += new EventHandler(buttonNumOfChanges_Click);
        }

        private void buttonNumOfChanges_Click(object i_Sender, EventArgs i_E)
        {
            
            // increase count
            m_NumOfChancesCount++;
            m_ButtonNumOfChances.Text = String.Format("Number of chances: {0}", m_NumOfChancesCount);
        }


    }
}
