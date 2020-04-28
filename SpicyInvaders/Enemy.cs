//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Enemy Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
    /// <summary>
    /// Enemy class
    /// </summary>
    public class Enemy : Character
    {
        private int _score;

        public int Score
        {
            get { return _score; }
        }

        /// <summary>
        /// Custom Constructor for the object Enemy
        /// </summary>
        /// 
        public Enemy(Vector2D pos): base(pos, 'O', 1)
        {
            _position = pos;
        }

        /// <summary>
        /// Destroys the Enemy
        /// </summary>
        public override void Destroy()
        {
            ErasePicture();
            GameManager.Instance.RemoveItem(this);
        }

        /// <summary>
        /// Update Enemy
        /// </summary>
        public override void Update(int tick)
        {
            Draw();
        }

        public override bool LoseLife(int loss)
        {
            _life -= loss;
            if (_life < 0)
            {
                Destroy();
                return true;
            }

            return false;
        }
    }
}
