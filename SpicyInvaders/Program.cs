//Auteur : JMY
//Date   : 03.09.2018
//Lieu   : ETML
//Description : Squelette pour SpaceInvaders en console

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
