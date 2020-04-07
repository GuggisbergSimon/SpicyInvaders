//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Player Class of Spicy Invaders

using System;
using System.Media;

namespace SpicyInvaders
{
    /// <summary>
    /// Player Class
    /// </summary>
    public class Player : SimpleObject
    {
        private Vector2D barrelOffset = new Vector2D(0, 1);
        private bool canShoot = true;
        private int _lives = 3;

        /// <summary>
        /// Player Constructor
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
        /// Destroys the Player
        /// </summary>
        public override void Destroy()
        {
            ErasePicture();
            GameManager.Instance.RemoveItem(this);
        }

        /// <summary>
        /// Update Player
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
                        GameManager.Instance.Bullets.Add(new Bullet(_position + barrelOffset, Direction.Up,
                            ConsoleColor.DarkMagenta, 2));
                    }

                    break;
                }
                case ConsoleKey.Escape:
                {
                    // Pause
                    Console.Clear();
                    GameManager.Instance.CurrentMenu = GameManager.Instance.Menus[4];
                    GameManager.Instance.State = GameManager.GameManagerState.Pause;
                    return;
                }
            }

            Draw();
        }

        public void LoseLife(int nbrLife)
        {
            _lives -= nbrLife;
            if (_lives < 0)
            {
                // Game over
                Console.Clear();
                GameManager.Instance.State = GameManager.GameManagerState.GameOver;
            }
        }

        private void UpdatePos(int move)
        {
            ErasePicture();
            _position.X += move;
        }
    }
}