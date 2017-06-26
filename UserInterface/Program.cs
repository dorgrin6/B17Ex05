/*
 * TODO:
 * 1. use partial classes for seperating between form's design and form's logic?
 * 2. shorter ctors?
 * 3. in FormGame avoid using index m_GameLines[0]
 * 4. make utilities for forms, when we want to use "buildFormBorders"
 * 5. in the UI consider using the GuessSize of the logic
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