//Authors       : HBN, KBY & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Main Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
    class Program
    {
        //Graphisme avancé du vaisseau
        const string ship = "H";
        const int shipY = 21;//position verticale du vaisseau

        static void Main(string[] args)
        {
            GameManager gameManager = new GameManager();
            gameManager.Start();

            int shipX = 50;
            int missileX = -1;
            int missileY = -1;

            bool missileFired = false;

            int tics = 0;

            while (true)
            {
                //Utilisateur a appuyé sur une touche ?
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    switch (key.Key)
                    {
                        //Touche fléchée gauche
                        case ConsoleKey.LeftArrow:
                            //Décalage de la position de référence
                            Console.SetCursorPosition(shipX, shipY);
                            Console.Write(" ");//Effacer l'ancienne position
                            shipX--;

                            break;

                        //MISSILE
                        case ConsoleKey.Spacebar:

                            //Un seul missile à la fois
                            if (!missileFired)
                            {
                                missileFired = true;
                                missileY = shipY;
                                missileX = shipX;//Placement du missile initial
                            }
                            break;
                    }

                }

                //On affiche le vaisseau à la bonne positition
                Console.SetCursorPosition(shipX, shipY);
                Console.Write(ship);

                //Gestion du missile
                if (missileFired)
                {
                    if (missileY > 0)
                    {
                        //Réduire la vitesse du missile
                        if (tics % 5 == 0)
                        {
                            //Effacer l'ancien missile
                            Console.SetCursorPosition(missileX, missileY);
                            Console.Write(" ");

                            //AFficher la nouvelle position
                            Console.SetCursorPosition(missileX, --missileY);
                            Console.Write("*");
                        }
                    }
                    else
                    {
                        //Fin du missile
                        missileFired = false;
                    }
                }

                //Temporisation FPS
                System.Threading.Thread.Sleep(10);

                tics++;
                if (tics == Int32.MaxValue)
                    tics = 0;

            }

        }
    }
}
