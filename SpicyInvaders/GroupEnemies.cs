//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Enemy Class of Spicy Invaders


using System;

namespace SpicyInvaders
{
    public class GroupEnemies
    {
        /// <summary>
        /// Attributes
        /// </summary>
        private readonly int _spaceX;
        private readonly int _spaceY;

        private int _sizeX;
        private int _sizeY;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public GroupEnemies()
        {
            _spaceX = 3;
            _spaceY = 2;
        }

        /// <summary>
        /// Custom Constructor
        /// </summary>
        public GroupEnemies(int sizeX, int sizeY)
        {
            _sizeX = sizeX;
            _sizeY = sizeY;
            _spaceX = 3;
            _spaceY = 2;
        }

        /// <summary>
        /// Spawn all the enemies in an array form
        /// </summary>
        public void SpawnEnemies()
        {
            //Add enemies to the list
            for (int i = 0; i < _sizeX * _sizeY; i++)
            {
                GameManager.Instance.Objects.Add(new Enemy());
            }

            //Spawn enemies
            foreach (Enemy enemy in GameManager.Instance.Objects)
            {
                enemy.X += _spaceX;
                enemy.Spawn();
            }
        }

        /// <summary>
        /// Enemy Movement
        /// </summary>
        public void Update()
        {
            foreach (Enemy enemy in GameManager.Instance.Objects)
            {
                Console.SetCursorPosition(enemy.X, enemy.Y);
                Console.Write((char)32);
                enemy.X += 2;
                enemy.Spawn();
            }
        }
    }
}
