using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace UserInterface
{
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

        public Button this[int key]
        {
            get
            {
                return m_ListOfButtons[key];
            }
        }
    }
}
