//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Player Class of Spicy Invaders

using System;
using System.Threading;

namespace SpicyInvaders
{
    public class Player : SimpleObject
    {
        //Representation of the player.
        private const char PLAYER_CHR = 'A';

        private bool canShoot = true;

        /// <summary>
        /// Default constructor of the class
        /// </summary>
        public Player()
        {
            _position.X = playerX;
            _position.Y = playerY;
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(PLAYER_CHR);
        }

        /// <summary>
        /// You can update the position of the player using this method.
        /// </summary>
        /// <param name="direction"></param>
        public override void Update()
        {
            switch (GameManager.Instance.Input.Key)
            {
                case ConsoleKey.LeftArrow:
                {
                    if (_position.X > 0)
                    {
                        UpdatePos(-1);
                    }

                    break;
                }
                case ConsoleKey.RightArrow:
                {
                    if (_position.X < Console.WindowWidth - 1)
                    {
                        UpdatePos(1);
                    }

                    break;
                }
                case ConsoleKey.Spacebar:
                {
                    if (canShoot)
                    {
                        //todo shoot a bullet
                    }

                    break;
                }
                default:
                {
                    break;
                }
            }
        }

        private void UpdatePos(int move)
        {
            Console.SetCursorPosition(_position.X, _position.Y);
            Console.Write(" ");
            _position.X += move;
            Console.SetCursorPosition(_position.X, _position.Y);
            Console.Write(PLAYER_CHR);
        }
    }
}