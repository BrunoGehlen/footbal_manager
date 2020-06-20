using System;

namespace footbal_manager
{
    class Program
    {
        static GameManagerController gameManager = new GameManagerController();

        static void Main(string[] args)
        {
            
            Console.WriteLine("\nHello!\n\nWelcome to FOOTBAL MANAGER!\n");

            gameManager.StartGame();
            Console.ReadKey(true); //true to not print input on console
        }
    }
}
