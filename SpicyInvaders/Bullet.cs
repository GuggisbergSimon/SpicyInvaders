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
        private int strength = 1;
        private bool _isMoving = true;

        public Direction Direction => _direction;
        
        /// <summary>
        /// Bullet Constructor
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="dir"></param>
        /// <param name="color"></param>
        /// <param name="speed"></param>
        public Bullet(Vector2D pos, Direction dir, ConsoleColor color, int speed): base(pos,'!')
        {
            _direction = dir;
            _color = color;
            _speed = speed;
        }

        /// <summary>
        /// Destroys the Bullet
        /// </summary>
        public override void Destroy()
        {
            ErasePicture();
            GameManager.Instance.RemoveItem(this);
        }

        /// <summary>
        /// Update Bullet
        /// </summary>
        public override void Update(int tick)
        {
            if (!_isMoving || tick % _speed != 0) return;
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
            
            //When a bullet meets a bullet
            foreach (var bullet in GameManager.Instance.Bullets)
            {
                if (bullet.Position != _position || _direction == bullet.Direction || bullet == this) continue;
                bullet.Destroy();
                Destroy();
            }

            //When a bullet meets an enemy
            foreach (var enemy in GameManager.Instance.Enemies)
            {
                if (enemy.Position != _position || _direction != Direction.Up) continue;
                enemy.LoseLife(strength);
                enemy.Destroy();
                Destroy();
            }

            //When a bullets meet the player
            if (GameManager.Instance.Player.Position == _position && _direction == Direction.Down)
            {
                Destroy();
                GameManager.Instance.Player.LoseLife(strength);
            }
        }
    }
}