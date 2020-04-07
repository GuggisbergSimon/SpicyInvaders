//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Simple object Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
    /// <summary>
    /// SimpleObject Class
    /// </summary>
    public abstract class SimpleObject
    {
        protected Vector2D _position;
        protected char _visual;
        
        /// <summary>
        /// Getter-Setter for Position
        /// </summary>
        public Vector2D Position
        {
            get => _position;
            set => _position = value;
        }

        /// <summary>
        /// Draw the simpleObject
        /// </summary>
        protected void Draw()
        {
            Console.SetCursorPosition(_position.X, _position.Y);
            Console.Write(_visual);
        }

        /// <summary>
        /// Reverts the pixels drawn on the position of the object
        /// </summary>
        protected void ErasePicture()
        {
            Console.SetCursorPosition(_position.X, Position.Y);
            Console.Write(" ");
        }

        /// <summary>
        /// Destroy the object
        /// </summary>
        public abstract void Destroy();
        
        /// <summary>
        /// Update method
        /// </summary>
        public abstract void Update();
    }
}
