namespace B17_Ex02
{
    public class BoardLine
    {
        private ushort m_ExistRightPlaceResult;

        private ushort m_ExistWrongPlaceResult;

        private char[] m_UserGuess;

        public BoardLine(ushort i_Amount, char i_Letter)
        {
            this.UserGuess = new char[i_Amount];
            for (int i = 0; i < i_Amount; i++)
            {
                m_UserGuess[i] = i_Letter;
            }
        }

        internal enum eResultLetter : ushort
        {
            ExistWrongPlace = 'X',

            ExistRightPlace = 'V'
        }

        public ushort ExistRightPlaceResult
        {
            get
            {
                return this.m_ExistRightPlaceResult;
            }

            set
            {
                this.m_ExistRightPlaceResult = value;
            }
        }

        public ushort ExistWrongPlaceResult
        {
            get
            {
                return this.m_ExistWrongPlaceResult;
            }

            set
            {
                this.m_ExistWrongPlaceResult = value;
            }
        }

        public char[] UserGuess
        {
            get
            {
                return this.m_UserGuess;
            }

            set
            {
                this.m_UserGuess = value;
            }
        }

        public char this[int i_Index]
        {
            get
            {
                return this.UserGuess[i_Index];
            }

            set
            {
                this.UserGuess[i_Index] = value;
            }
        }
    }
}