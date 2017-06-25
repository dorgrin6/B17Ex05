using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UserInterface
{
    public class ResultsButtonsList : ButtonsList
    {
        private const ushort k_SpaceOffset = 5;

        private enum eResultButtonSize
        {
            Width = 15,

            Height = 15
        }

        public ResultsButtonsList(Point i_Location) : base()
        {
            foreach (Button btn in m_ListOfButtons)
            {
                btn.Size = new Size((int)eResultButtonSize.Width, (int)eResultButtonSize.Height);
                btn.Enabled = false;
            }

            m_ListOfButtons[0].Location = i_Location;
            i_Location.X += ((int)eResultButtonSize.Width + k_SpaceOffset);
            m_ListOfButtons[1].Location = i_Location;
            i_Location.X -= ((int)eResultButtonSize.Width + k_SpaceOffset);
            i_Location.Y += ((int)eResultButtonSize.Height + k_SpaceOffset);
            m_ListOfButtons[2].Location = i_Location;
            i_Location.X += ((int)eResultButtonSize.Width + k_SpaceOffset);
            m_ListOfButtons[3].Location = i_Location;
        }
    }
}
