//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Main Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 50);

            MainMenu menu = new MainMenu();
            menu.Refresh(true);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        menu.Refresh(false);
                        break;
                    case ConsoleKey.UpArrow:
                        menu.Refresh(true);
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
