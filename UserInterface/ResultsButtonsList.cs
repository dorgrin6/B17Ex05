namespace UserInterface
{
    using System.Drawing;
    using System.Windows.Forms;

    public class ResultsButtonsList : ButtonsList
    {
        private const ushort k_SpaceOffset = 5;

        public ResultsButtonsList(Point i_Location)
            : base()
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

        private enum eResultButtonSize
        {
            Width = 15,

            Height = 15
        }

        public void ShowResults(ushort i_ExistRightPlace, ushort i_ExistWrongPlace)
        {
            foreach (Button btn in m_ListOfButtons)
            {
                if (i_ExistRightPlace > 0)
                {
                    btn.BackColor = ColorUtilities.ExistRightPlaceColor;
                    i_ExistRightPlace--;
                }
                else if (i_ExistWrongPlace > 0)
                {
                    btn.BackColor = ColorUtilities.ExistWrongPlaceColor;
                    i_ExistWrongPlace--;
                }
            }
        }
    }
}