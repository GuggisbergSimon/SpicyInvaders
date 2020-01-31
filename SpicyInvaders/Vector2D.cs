//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Vector2D Struct of Spicy Invaders

namespace SpicyInvaders
{
    public struct Vector2D
    {
        private int _x;
        private int _y;

        /// <summary>
        /// get-set the X-axis
        /// </summary>
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        /// <summary>
        /// get-set the Y-axis
        /// </summary>
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Vector2D constructor
        /// </summary>
        /// <param name="x">X-axis</param>
        /// <param name="y">Y-axis</param>
        public Vector2D(int x, int y)
        {
            _x = x;
            _y = y;

        }

        /// <summary>
        /// equals operator
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator ==(Vector2D v1, Vector2D v2)
        {
            return v1.Equals(v2);
        }

        /// <summary>
        /// not equals operator
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static bool operator !=(Vector2D v1, Vector2D v2)
        {
            return !v1.Equals(v2);
        }

        /// <summary>
        /// equals operation
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public override bool Equals(object v)
        {
            if (!(v is Vector2D))
            {
                return false;
            }

            Vector2D objAsVector2D = (Vector2D)v;
            return objAsVector2D.X == _x && objAsVector2D.Y == _y;

        }

        /// <summary>
        /// addition operation
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector2D operator +(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1._x + v2._x, v1._y + v2._y);
        }

        /// <summary>
        /// substraction operation
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="v2"></param>
        /// <returns></returns>
        public static Vector2D operator -(Vector2D v1, Vector2D v2)
        {
            return new Vector2D(v1._x - v2.X, v1._y - v2._y);
        }

        /// <summary>
        /// multiplication operation
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Vector2D operator *(Vector2D v1, int k)
        {
            return new Vector2D(v1._x * k, v1._y * k);
        }

        /// <summary>
        /// division operation
        /// </summary>
        /// <param name="v1"></param>
        /// <param name="k"></param>
        /// <returns></returns>
        public static Vector2D operator /(Vector2D v1, int k)
        {
            return new Vector2D(v1._x / k, v1._y / k);
        }
    }
}