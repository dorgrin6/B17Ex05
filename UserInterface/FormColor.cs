using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UserInterface
{
    public class FormColor : Form
    {
        private const ushort k_numOfColors = 8;

        private List<Button> m_ListOfButtons = new List<Button>(k_numOfColors);

        private Color m_SelectedColor;

        private const ushort k_SpaceOffset = 10;

        private const string k_FormTitle = "Choose Color:";

        private enum eFormStartLocation
        {
            Left = 20,

            Top = 20
        }

        private enum eDefaultFormSize
        {
            Width = 270,

            Height = 100
        }

        private enum eColorButtonSize
        {
            Width = 50,

            Height = 50
        }


        public FormColor()
        {
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Text = k_FormTitle;
            for (int i=0; i < k_numOfColors; i++)
            {
                m_ListOfButtons.Add(new Button());
            }
            
            
            m_ListOfButtons[0].BackColor = ColorUtilities.Purple;
            m_ListOfButtons[1].BackColor = ColorUtilities.Red;
            m_ListOfButtons[2].BackColor = ColorUtilities.Lime;
            m_ListOfButtons[3].BackColor = ColorUtilities.Cyan;
            m_ListOfButtons[4].BackColor = ColorUtilities.Blue;
            m_ListOfButtons[5].BackColor = ColorUtilities.Yellow;
            m_ListOfButtons[6].BackColor = ColorUtilities.Brown;
            m_ListOfButtons[7].BackColor = ColorUtilities.White;
        }

        public Color SelectedColor
        {
            get
            {
                return m_SelectedColor;
            }
        }

        private void button_Click(object i_Sender, EventArgs i_Evet)
        {
            m_SelectedColor = (i_Sender as Button).BackColor;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override void OnLoad(EventArgs i_Event)
        {
            base.OnLoad(i_Event);

            initializeComponent();
        }

        private void initializeComponent()
        {
            Point location = new Point((int)eFormStartLocation.Left, (int)eFormStartLocation.Top);
            int countColors = 0;

            foreach (Button btn in m_ListOfButtons)
            {
                btn.Size = new Size((int)eColorButtonSize.Width, (int)eColorButtonSize.Height);
                btn.Click += new EventHandler(button_Click);
                if (countColors == 4)
                {
                    location.X = (int)eFormStartLocation.Left;
                    location.Y += (int)eColorButtonSize.Height + k_SpaceOffset;
                }

                btn.Location = location;
                this.Controls.Add(btn);
                location.X += ((int)eColorButtonSize.Width + k_SpaceOffset);
                countColors++;
            }

            buildFormBorder();
        }

        private void buildFormBorder()
        {
            int height = 0;
            int width = 0;
            int linesAmount = 2;
            int lineHeight = (int)eColorButtonSize.Height + k_SpaceOffset;

            height = (int)eFormStartLocation.Top + lineHeight * linesAmount;
            width = (int)eDefaultFormSize.Width;

            this.ClientSize = new Size(width, height);
        }

    }
}
