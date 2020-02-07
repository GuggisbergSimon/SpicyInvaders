//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Player Class of Spicy Invaders

using System;
using System.Threading;

namespace SpicyInvaders
{
    public class Player
    {
        //Representation of the player.
        private const char PLAYER_CHR = 'A';

        //Coordinates of the player in the Console.
        private int _X;
        private int _Y;


        //Properties
        public int X
        {
            get { return _X; }
            set { _X = value; }
        }

        public int Y
        {
            get { return _Y; }
            set { _Y = value; }
        }

        /// <summary>
        /// Default constructor of the class
        /// </summary>
        public Player()
        {

        }

        /// <summary>
        /// Custom Constructor of the class "Player"
        /// </summary>
        /// <param name="X"></param>
        /// <param name="Y"></param>
        public Player(int X, int Y)
        {
            _X = X;
            _Y = Y;
            Console.SetCursorPosition(X, Y);
            Console.Write(PLAYER_CHR);
        }

        /// <summary>
        /// You can update the position of the player using this method.
        /// </summary>
        /// <param name="direction"></param>
        public void Update(Direction direction)
        {
            Console.Write("\b ");

            if (direction == Direction.Left)
            {
                X--;
            }
            else if(direction == Direction.Right)
            {
                X++;
            }

            Console.SetCursorPosition(X, Y);
            Console.Write(PLAYER_CHR);
        }
    }
}
