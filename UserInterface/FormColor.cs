﻿namespace UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public class FormColor : Form
    {
        private const string k_FormTitle = "Choose Color:";

        private const ushort k_NumOfColors = 8;

        private const ushort k_SpaceOffset = 10;

        private readonly List<Button> sr_ListOfButtons = new List<Button>(k_NumOfColors);

        private Color m_SelectedColor;

        public FormColor()
        {
            this.ClientSize = new Size((int)eDefaultClientSize.Width, (int)eDefaultClientSize.Height);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.Text = k_FormTitle;
            for (int i = 0; i < k_NumOfColors; i++)
            {
                sr_ListOfButtons.Add(new Button());
            }

            sr_ListOfButtons[0].BackColor = ColorUtilities.Purple;
            sr_ListOfButtons[1].BackColor = ColorUtilities.Red;
            sr_ListOfButtons[2].BackColor = ColorUtilities.Lime;
            sr_ListOfButtons[3].BackColor = ColorUtilities.Cyan;
            sr_ListOfButtons[4].BackColor = ColorUtilities.Blue;
            sr_ListOfButtons[5].BackColor = ColorUtilities.Yellow;
            sr_ListOfButtons[6].BackColor = ColorUtilities.Brown;
            sr_ListOfButtons[7].BackColor = ColorUtilities.White;
        }

        private enum eColorButtonSize
        {
            Width = 50,

            Height = 50
        }

        private enum eDefaultClientSize
        {
            Width = 270,

            Height = 150
        }

        private enum eFormStartLocation
        {
            Left = 20,

            Top = 20
        }

        public Color SelectedColor
        {
            get
            {
                return m_SelectedColor;
            }
        }

        protected override void OnLoad(EventArgs i_Event)
        {
            base.OnLoad(i_Event);

            initializeComponent();
        }

        private void button_Click(object i_Sender, EventArgs i_Evet)
        {
            m_SelectedColor = (i_Sender as Button).BackColor;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void initializeComponent()
        {
            Point location = new Point((int)eFormStartLocation.Left, (int)eFormStartLocation.Top);
            int countColors = 0;

            foreach (Button btn in sr_ListOfButtons)
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
        }
    }
}