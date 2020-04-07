//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Enemy Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
    public class Enemy : SimpleObject
    {
        //Representation of the enemy.
        private readonly char _enemyChar;

        //Coordinates of the enemy in the Console.
        private int _x;
        private int _y;
        private int _lastSpawnX;
        private int _lastSpawnY;

        //Properties
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        public char EnemyChar
        {
            get { return _enemyChar; }
        }

        /// <summary>
        /// Default Constructor for the object Enemy
        /// </summary>
        public Enemy()
        {
            _enemyChar = 'O';
        }

        /// <summary>
        /// Custom Constructor for the object Enemy
        /// </summary>
        public Enemy(int x, int y)
        {
            _enemyChar = 'O';
            _x = x;
            _y = y;
        }

        public void Kill()
        {

        }

        public void Spawn()
        {
            Console.SetCursorPosition(_lastSpawnX, _lastSpawnY);
            Console.Write(" ");

            _lastSpawnX = _x;
            _lastSpawnY = _y;

            Console.SetCursorPosition(_x, _y);
            Console.Write(_enemyChar);
        }

        public override void Update()
        {
            
        }
    }
}
