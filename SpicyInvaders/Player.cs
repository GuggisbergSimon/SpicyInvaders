//  ETML
//  Auteur : SGG, KBY, HGN, YFA
//  Date : 24.01.20
//  Description : Classe concernant tout ce qui touche au joueur (vaisseau).

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
        public void Move(Direction direction)
        {
            Console.Write("\b ");

            if(direction == Direction.Left)
            {
                PlayerX--;
            }
            else if(direction == Direction.Right)
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
