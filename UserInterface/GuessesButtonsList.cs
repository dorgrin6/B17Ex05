namespace UserInterface
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public class GuessesButtonsList : ButtonsList
    {
        private const ushort k_SpaceOffset = 10;

        private readonly FormColor r_FormColor = new FormColor();

        private ushort m_LeftToSelectColor = k_GuessSize;

        public GuessesButtonsList(Point i_Location)
            : base()
        {
            foreach (Button btn in m_ListOfButtons)
            {
                btn.Size = new Size((int)eGuessButtonSize.Width, (int)eGuessButtonSize.Height);
                btn.Location = i_Location;
                i_Location.X += ((int)eGuessButtonSize.Width + k_SpaceOffset);
                btn.Click += new EventHandler(ButtonClick);
            }
        }

        private enum eGuessButtonSize
        {
            Width = 50,

            Height = 50
        }

        public ushort LeftToSelectColor
        {
            get
            {
                return m_LeftToSelectColor;
            }
        }

        public void CopyButtonsColors(List<Button> i_SourceButtons)
        {
            int i = 0;

            foreach (Button btn in m_ListOfButtons)
            {
                btn.BackColor = i_SourceButtons[i].BackColor;
                i++;
            }
        }

        public void DarkButtons()
        {
            EnableButtons(false);
            foreach (Button btn in m_ListOfButtons)
            {
                btn.BackColor = Color.Black;
            }
        }

        public void EnableButtons(bool i_IsEnabled)
        {
            foreach (Button btn in m_ListOfButtons)
            {
                btn.Enabled = i_IsEnabled;
            }
        }

        public int GetLengthX()
        {
            return ((int)eGuessButtonSize.Width + k_SpaceOffset) * k_GuessSize;
        }

        public int GetLengthY()
        {
            return (int)eGuessButtonSize.Height + k_SpaceOffset;
        }

        protected void ButtonClick(object i_Sender, EventArgs i_Evet)
        {
            Button colorButton = (i_Sender as Button);

            r_FormColor.StartPosition = FormStartPosition.Manual;
            r_FormColor.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            r_FormColor.ShowDialog();
            if (r_FormColor.DialogResult != DialogResult.Cancel)
            {
                if (colorButton.BackColor == Control.DefaultBackColor)
                {
                    m_LeftToSelectColor--;
                }

                colorButton.BackColor = r_FormColor.SelectedColor;
            }
        }
    }
}