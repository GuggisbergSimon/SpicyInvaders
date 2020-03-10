//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Bullet Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
    public class Bullet : SimpleObject
    {
        private Direction _direction;
        private ConsoleColor _color;
        private int _speed;
        private bool _isMoving = true;

        public Bullet(Vector2D pos, Direction dir, ConsoleColor color, int speed)
        {
            _visual = '!';
            _position = pos;
            _direction = dir;
            _color = color;
            _speed = speed;
        }

        public override void Update()
        {
            if (_isMoving)
            {
                if (_direction == Direction.Up && _position.Y > 0)
                {
                    UpdatePos(-Vector2D.Up);
                }
                else if (_direction == Direction.Down && _position.Y <= Console.WindowHeight)
                {
                    UpdatePos(Vector2D.Up);
                }
                else if (_direction == Direction.Right && _position.X <= Console.WindowWidth)
                {
                    UpdatePos(Vector2D.Right);
                }
                else if (_direction == Direction.Left && _position.X > 0)
                {
                    UpdatePos(-Vector2D.Right);
                }
                else
                {
                    _isMoving = false;
                    Destroy();
                }
            }
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
            
            foreach (var obj in GameManager.Instance.Objects)
            {
                if (obj.Position == _position && obj != this)
                {
                    obj.Destroy();
                    Destroy();
                    //todo code other interactions here
                }
            }
            Draw();
        }
    }
}