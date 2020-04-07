//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Bullet Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
    /// <summary>
    /// Bullet Class
    /// </summary>
    public class Bullet : SimpleObject
    {
        private Direction _direction;
        private ConsoleColor _color;
        private int _speed;
        private bool _isMoving = true;

        /// <summary>
        /// Bullet Constructor
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="color"></param>
        /// <param name="speed"></param>
        public Bullet(Vector2D pos, Direction dir, ConsoleColor color, int speed)
        {
            _visual = '!';
            _position = pos;
            _direction = dir;
            _color = color;
            _speed = speed;
        }

        public override void Destroy()
        {
            ErasePicture();
            GameManager.Instance.RemoveItem(this);
        }

        /// <summary>
        /// Update Bullet
        /// </summary>
        public override void Update()
        {
            if (!_isMoving) return;
            switch (_direction)
            {
                case Direction.Up when _position.Y > 0:
                    UpdatePos(-Vector2D.Up);
                    break;
                case Direction.Down when _position.Y <= Console.WindowHeight:
                    UpdatePos(Vector2D.Up);
                    break;
                case Direction.Right when _position.X <= Console.WindowWidth:
                    UpdatePos(Vector2D.Right);
                    break;
                case Direction.Left when _position.X > 0:
                    UpdatePos(-Vector2D.Right);
                    break;
                default:
                    _isMoving = false;
                    Destroy();
                    break;
            }
        }

        private void UpdatePos(Vector2D move)
        {
            ErasePicture();
            _position += move;
            Draw();
            
            foreach (var bullet in GameManager.Instance.Bullets)
            {
                if (bullet.Position != _position || bullet == this) continue;
                bullet.Destroy();
                Destroy();
            }

            foreach (var enemy in GameManager.Instance.Enemies)
            {
                if (enemy.Position != _position) continue;
                enemy.Destroy();
                Destroy();
            }
            
            //todo code other interactions here
        }
    }
}