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
    public class Enemy : SimpleObject
    {

        /// <summary>
        /// Custom Constructor for the object Enemy
        /// </summary>
        public Enemy(Vector2D pos)
        {
            _visual = 'O';
            _position = pos;
        }

        /// <summary>
        /// Update Enemy
        /// </summary>
        public override void Update()
        {
            Draw();
        }
    }
}
