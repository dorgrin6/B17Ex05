using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UserInterface
{
    public class GuessesButtonsList : ButtonsList
    {
        private const ushort k_SpaceOffset = 10;

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
                //TODO: we need to attach each button the colors menu
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
    }
}
