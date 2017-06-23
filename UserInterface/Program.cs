namespace UserInterface
{
    using B17_Ex02;

    public class Program
    {
        public static void Main()
        {
            GameLogic gameLogic = new GameLogic();

            FormStart formStart = new FormStart();

            formStart.ShowDialog();
        }
    }
}
