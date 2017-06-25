using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UserInterface
{
    public class GuessesButtonsList : ButtonsList
    {
        private const ushort k_SpaceOffset = 10;

        private readonly FormColor m_FormColor = new FormColor();

        private enum eGuessButtonSize
        {
            Width = 50,

            Height = 50
        }

        public GuessesButtonsList(Point i_Location) : base()
        {
            foreach (Button btn in m_ListOfButtons)
            {
                btn.Size = new Size((int)eGuessButtonSize.Width, (int)eGuessButtonSize.Height);
                btn.Location = i_Location;
                i_Location.X += ((int)eGuessButtonSize.Width + k_SpaceOffset);
                btn.Click += new EventHandler(button_Click);
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

        public void DarkButtons()
        {
            bool isEnabled = false;

            EnableButtons(isEnabled);
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

        private void button_Click(object i_Sender, EventArgs i_Evet)
        {
            m_FormColor.ShowDialog();
            if (m_FormColor.DialogResult != DialogResult.Cancel)
            {
                (i_Sender as Button).BackColor = m_FormColor.SelectedColor;
            }
        }

        public bool isAllColorsSelected()
        {
            bool isColorSelected = true;

            foreach(Button btn in m_ListOfButtons)
            {
                if (btn.BackColor == Control.DefaultBackColor)
                {
                    isColorSelected = false;
                    break;
                }
            }

            return isColorSelected;
        }
        

    }
}
