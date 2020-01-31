//Authors       : HBN, KBY & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Player Class of Spicy Invaders

using System;
using System.Threading;

namespace SpicyInvaders
{
    public enum Direction
    {
        Left,
        Right,
        Top,
        Down
    }

    public class Player
    {
        //Representation of the player.
        private const char PLAYER_CHR = 'A';

        //Coordinates of the player in the Console.
        private int _playerX;
        private int _playerY;

        /// <summary>
        /// Constructor of the class "Player"
        /// </summary>
        /// <param name="aPlayerX"></param>
        /// <param name="aPlayerY"></param>
        public Player(int aPlayerX, int aPlayerY)
        {
            _playerX = aPlayerX;
            _playerY = aPlayerY;
            Console.SetCursorPosition(PlayerX, PlayerY);
            Console.Write(PLAYER_CHR);
        }

        /// <summary>
        /// You can move the player using this method.
        /// </summary>
        /// <param name="direction"></param>
        public void Update()
        {
            Console.Write("\b ");
            ConsoleKeyInfo key = Console.ReadKey(true);

            if (key.Key == ConsoleKey.LeftArrow)
            {
                PlayerX--;
            }
            else if(key.Key == ConsoleKey.RightArrow)
            {
                PlayerX++;
            }

            Console.SetCursorPosition(PlayerX, PlayerY);
            Console.Write(PLAYER_CHR);
        }

        //Getter-Setters
        
        public int PlayerX
        {
            get { return _playerX; }
            set { _playerX = value; }
        }

        public int PlayerY
        {
            get { return _playerY; }
            set { _playerY = value; }
        }
    }
}
