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
    public class Player : Character
    {
        private Vector2D barrelOffset = new Vector2D(0, 1);
        private bool canShoot = true;

        /// <summary>
        /// Player Constructor
        /// </summary>
        public Player(Vector2D position): base(position, 'A', (int) GameManager.Instance.Difficulty)
        {
            Console.SetCursorPosition(position.X,position.Y);
            Draw();
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
        public override void Update(int tick)
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

        /// <summary>
        /// Makes the player lose some life
        /// </summary>
        /// <param name="loss">the number of life to remove</param>
        /// <returns>true if dead</returns>
        public override bool LoseLife(int loss)
        {
            _life -= loss;
            if (_life < 0)
            {
                return true;
                //todo gameover
            }

            return false;
        }

        private void UpdatePos(int move)
        {
            ErasePicture();
            _position.X += move;
        }
    }
}