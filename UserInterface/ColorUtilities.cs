using System;
using System.Text;
using System.Drawing;
using System.Collections.Generic;

namespace UserInterface
{
    public class ColorUtilities
    {
        private static readonly Color k_Purple = Color.Purple;

        private static readonly Color k_Red = Color.Red;

        private static readonly Color k_Lime = Color.Lime;

        private static readonly Color k_Cyan = Color.Cyan;

        private static readonly Color k_Blue = Color.Blue;

        private static readonly Color k_Yellow = Color.Yellow;

        private static readonly Color k_Brown = Color.Brown;

        private static readonly Color k_White = Color.White;

        private static readonly Dictionary<Color,char> m_ColorLetter = new Dictionary<Color, char>() {
            { k_Purple , 'A' } , { k_Red , 'B' } , { k_Lime , 'C' }, { k_Cyan , 'D' } ,
            { k_Blue , 'E' } , { k_Yellow , 'F' } , { k_Brown , 'G' } , { k_White , 'H'} };


        public static Color Purple
        {
            get
            {
                return k_Purple;
            }
        }

        public static Color Red
        {
            get
            {
                return k_Red;
            }
        }

        public static Color Lime
        {
            get
            {
                return k_Lime;
            }
        }

        public static Color Cyan
        {
            get
            {
                return k_Cyan;
            }
        }

        public static Color Blue
        {
            get
            {
                return k_Blue;
            }
        }

        public static Color Yellow
        {
            get
            {
                return k_Yellow;
            }
        }

        public static Color Brown
        {
            get
            {
                return k_Brown;
            }
        }

        public static Color White
        {
            get
            {
                return k_White;
            }
        }

        public static string ConvertColorsToString(List<Color> i_Colors)
        {
            StringBuilder guessAsString = new StringBuilder();

            foreach(Color clr in i_Colors)
            {
                guessAsString.Append(m_ColorLetter[clr]);
            }

            return guessAsString.ToString();
        }
    }
}
