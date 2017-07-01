namespace UserInterface
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public class ButtonsList
    {
        protected const ushort k_GuessSize = 4;

        protected List<Button> m_ListOfButtons = new List<Button>(k_GuessSize);

        public ButtonsList()
        {
            for (int i = 0; i < k_GuessSize; i++)
            {
                m_ListOfButtons.Add(new Button());
            }
        }

        public List<Button> List
        {
            get
            {
                return m_ListOfButtons;
            }
        }

        public Button this[int i_Key]
        {
            get
            {
                return m_ListOfButtons[i_Key];
            }
        }

        public List<Color> GetColorsList()
        {
            List<Color> colors = new List<Color>();

            foreach (Button btn in m_ListOfButtons)
            {
                colors.Add(btn.BackColor);
            }

            return colors;
        }
    }
}