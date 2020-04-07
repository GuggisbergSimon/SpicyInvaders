﻿//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Player Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
    public class Player : SimpleObject
    {
        //Representation of the player.
        private Vector2D barrelOffset = new Vector2D(0, 1);

        private bool canShoot = true;

        /// <summary>
        /// Constructor of the class
        /// </summary>
        public Player(int playerX, int playerY)
        {
            _visual = 'A';
            _position.X = playerX;
            _position.Y = playerY;
            Console.SetCursorPosition(playerX, playerY);
            Console.Write(_visual);
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
                        GameManager.Instance.Objects.Add(new Bullet(_position + barrelOffset, Direction.Up,
                            ConsoleColor.DarkMagenta, 2));
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
            Draw();
        }
    }
}