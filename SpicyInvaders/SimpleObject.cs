//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Simple object Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
    public abstract class SimpleObject
    {
        protected Vector2D _position;
        protected char _visual;
        public Vector2D Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public void Draw()
        {
            Console.SetCursorPosition(_position.X, _position.Y);
            Console.Write(_visual);
        }

        protected void ErasePicture()
        {
            Console.SetCursorPosition(_position.X, Position.Y);
            Console.Write(" ");
        }

        public void Destroy()
        {
            ErasePicture();
            GameManager.Instance.RemoveItem(this);
        }
        
        public abstract void Update();
    }
}
