namespace UserInterface
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Text;

    public static class ColorUtilities
    {
        private static readonly Color sr_Blue = Color.Blue;

        private static readonly Color sr_Brown = Color.Brown;

        private static readonly Color sr_Cyan = Color.Cyan;

        private static readonly Color sr_ExistRightPlaceColor = Color.Black;

        private static readonly Color sr_ExistWrongPlaceColor = Color.Yellow;

        private static readonly Color sr_Lime = Color.Lime;

        private static readonly Color sr_Purple = Color.Purple;

        private static readonly Color sr_Red = Color.Red;

        private static readonly Color sr_White = Color.White;

        private static readonly Color sr_Yellow = Color.Yellow;

        private static readonly Dictionary<Color, char> sr_ColorLetter = new Dictionary<Color, char>() {
            { sr_Purple , 'A' } , { sr_Red , 'B' } , { sr_Lime , 'C' }, { sr_Cyan , 'D' } ,
            { sr_Blue , 'E' } , { sr_Yellow , 'F' } , { sr_Brown , 'G' } , { sr_White , 'H'} };

        public static Color Blue
        {
            get
            {
                return sr_Blue;
            }
        }

        public static Color Brown
        {
            get
            {
                return sr_Brown;
            }
        }

        public static Color Cyan
        {
            get
            {
                return sr_Cyan;
            }
        }

        public static Color ExistRightPlaceColor
        {
            get
            {
                return sr_ExistRightPlaceColor;
            }
        }

        public static Color ExistWrongPlaceColor
        {
            get
            {
                return sr_ExistWrongPlaceColor;
            }
        }

        public static Color Lime
        {
            get
            {
                return sr_Lime;
            }
        }

        public static Color Purple
        {
            get
            {
                return sr_Purple;
            }
        }

        public static Color Red
        {
            get
            {
                return sr_Red;
            }
        }

        public static Color White
        {
            get
            {
                return sr_White;
            }
        }

        public static Color Yellow
        {
            get
            {
                return sr_Yellow;
            }
        }

        public static string ConvertColorsToLetters(List<Color> i_Colors)
        {
            StringBuilder guessAsString = new StringBuilder();

            foreach (Color clr in i_Colors)
            {
                guessAsString.Append(sr_ColorLetter[clr]);
            }

            return guessAsString.ToString();
        }
    }
}