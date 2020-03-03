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
            GameManager.Instance.EnemyArray = new Enemy[_sizeX, _sizeY];

            //Add enemies to the list
            for (int i = 0; i < _sizeX; i++)
            {
                for (int j = 0; j < _sizeY; j++)
                {
                    GameManager.Instance.EnemyArray[i, j] = new Enemy()
                    {
                        X = _spaceX * (i + 1),
                        Y = _spaceY * (j + 1)
                    };
                    GameManager.Instance.EnemyArray[i, j].Spawn();
                }
            }
        }

        /// <summary>
        /// Enemy Movement
        /// </summary>
        public void Update()
        {
            foreach (Enemy enemy in GameManager.Instance.EnemyArray)
            {
                enemy.X += _spaceX - 2;
                enemy.Spawn();
            }
        }
    }
}
