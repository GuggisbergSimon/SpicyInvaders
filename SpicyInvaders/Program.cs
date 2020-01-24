//Authors       : HBN, KBY & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Main Class of Spicy Invaders

﻿using System;

namespace SpicyInvaders
{
    class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            //gameManager.Start();

            Console.CursorVisible = false;
            Player Ship = new Player(35, 20);

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);

                switch(key.Key)
                {
                    case ConsoleKey.LeftArrow:
                        Ship.Move(Direction.Left);
                        break;
                    case ConsoleKey.RightArrow:
                        Ship.Move(Direction.Right);
                        break;
                }
            }
        }
    }
}
