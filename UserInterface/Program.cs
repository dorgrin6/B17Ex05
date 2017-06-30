/*
 * TODO:
 * 1. use partial classes for seperating between form's design and form's logic?
 * 2. shorter ctors?
 * */

namespace UserInterface
{
    public class Program
    {
        public static void Main()
        {
            FormGame formGame = new FormGame();
            formGame.Run();
        }
    }
}