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

        private ushort m_LeftToSelectColor = k_GuessSize;

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

        public ushort LeftToSelectColor
        {
            get
            {
                return m_LeftToSelectColor;
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
            Button colorButton = (i_Sender as Button);

            m_FormColor.StartPosition = FormStartPosition.Manual;
            m_FormColor.Location = new Point(Cursor.Position.X, Cursor.Position.Y);
            m_FormColor.ShowDialog();
            if (m_FormColor.DialogResult != DialogResult.Cancel)
            {
                if (colorButton.BackColor == Control.DefaultBackColor)
                {
                    m_LeftToSelectColor--;
                }

                colorButton.BackColor = m_FormColor.SelectedColor;
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
        
        public void CopyButtonsColors(List<Button> i_SourceButtons)
        {
            int i = 0;

            foreach (Button btn in m_ListOfButtons)
            {
                btn.BackColor = i_SourceButtons[i].BackColor;
                i++;
            }
        }
    }
}
