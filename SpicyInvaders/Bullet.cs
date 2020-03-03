//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Bullet Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
    /// <summary>
    /// 
    /// </summary>
    public class Bullet : SimpleObject
    {
        private Direction _direction;
        private ConsoleColor _color;
        private int _speed;
        private bool _isMoving = true;

        public Bullet(Vector2D pos, Direction dir, ConsoleColor color, int speed)
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

        public override void Update()
        {
            if (_isMoving)
            {
                switch (_direction)
                {
                    case Direction.Down:
                    {
                        if (_position.Y <= Console.WindowHeight)
                        {
                            UpdatePos(Vector2D.Up);
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
                        else
                        {
                            _isMoving = false;
                            Destroy();
                        }

                        break;
                    }
                }
            }

        }

        public void Destroy()
        {
            ErasePicture();
            GameManager.Instance.RemoveItem(this);
        }

        private void ErasePicture()
        {
            Console.SetCursorPosition(_position.X, Position.Y);
            Console.Write(" ");
        }

        public void UpdatePos(Vector2D move)
        {

            if (GameManager.Instance.Player.Position == _position)
            {
                GameManager.Instance.Player.Draw();
            }
            else
            {
                ErasePicture();
            }
            _position += move;
            Draw();
        }
    }
}