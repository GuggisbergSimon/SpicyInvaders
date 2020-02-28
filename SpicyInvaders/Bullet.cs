//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Bullet Class of Spicy Invaders

using System;
using System.Globalization;

namespace SpicyInvaders
{
    /// <summary>
    /// 
    /// </summary>
    public class Bullet : SimpleObject
    {
        private Direction _direction;
        private System.ConsoleColor _color;
        private int _speed;

        public Bullet(Vector2D pos, Direction dir, System.ConsoleColor color, int speed)
        {
            _position = pos;
            _direction = dir;
            _color = color;
            _speed = speed;
        }

        public override void Draw()
        {
            Console.SetCursorPosition(_position.X, _position.Y);
            Console.Write("!");
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Update()
        {
            switch (_direction)
            {
                case Direction.Down:
                    {
                        if (_position.Y <= Console.WindowHeight)
                        {
                            UpdatePos(Vector2D.Up);
                        }
                        else
                        {
                            Destroy();
                        }

                        break;
                    }
                case Direction.Left:
                    {
                        if (_position.X > 0)
                        {
                            UpdatePos(-Vector2D.Right);
                        }

                        break;
                    }
                case Direction.Right:
                    {
                        if (_position.X <= Console.WindowWidth)
                        {
                            UpdatePos(Vector2D.Right);
                        }

                        break;
                    }
                case Direction.Top:
                    {
                        if (_position.Y > 0)
                        {
                            UpdatePos(-Vector2D.Up);
                        }

                        break;
                    }
            }

        }

        public void Destroy()
        {
            ErasePicture();
            GameManager.Instance.Bullets[GameManager.Instance.Bullets.IndexOf(this)] = null;
        }

        private void ErasePicture()
        {

            Console.SetCursorPosition(_position.X, Position.Y);
            Console.Write(" ");
        }

        public void UpdatePos(Vector2D move)
        {
            ErasePicture();
            _position += move;
            Draw();
        }
    }
}