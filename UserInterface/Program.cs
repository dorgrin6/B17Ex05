namespace UserInterface
{
    using B17_Ex02;

    public class Program
    {
        public static void Main()
        {
            GameLogic gameLogic = new GameLogic();

            StartForm startForm = new StartForm();

            startForm.ShowDialog();
        }
    }
}
