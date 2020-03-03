//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Simple object Class of Spicy Invaders

namespace SpicyInvaders
{
    public abstract class SimpleObject
    {
        protected Vector2D _position;
        protected char[,] _visual;

        public abstract void Draw();

        public abstract void Update();
    }
}
