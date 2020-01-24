using System;
using System.Threading;

namespace SpicyInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Player Ship = new Player(35, 20);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch(key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        Ship.Move(Directions.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        Ship.Move(Directions.Right);
                        break;
                }
            }
        }
    }
}
