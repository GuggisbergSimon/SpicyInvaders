//Authors       : HDN, YFA, KBY & SGG
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
            GameManager gameManager = new GameManager();

            gameManager.Start();
            gameManager.MainMenu();
        }
    }
}
