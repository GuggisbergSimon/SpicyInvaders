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
                GameManager.Instance.Enemies.Add(new Enemy(Vector2D.Zero));
            }

            //Spawn enemies
            foreach (var enemy in GameManager.Instance.Enemies)
            {
                enemy.Position += Vector2D.Right * _spaceX;
            }
        }

        /// <summary>
        /// Enemy Movement
        /// </summary>
        public void Update()
        {
            foreach (var enemy in GameManager.Instance.Enemies)
            {
                Console.SetCursorPosition(enemy.Position.X, enemy.Position.Y);
                Console.Write((char) 32);
                enemy.Position += Vector2D.Right * 2;
            }
        }
    }
}