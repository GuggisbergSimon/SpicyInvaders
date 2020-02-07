//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Enemy Class of Spicy Invaders


namespace SpicyInvaders
{
    public class GroupEnemies
    {
        private int _posX;
        private int _posY;

        public void SpawnEnemies()
        {
            for (int i = 0; i < 90; i++)
            {
                GameManager.Instance.Enemies.Add(new Enemy());
            }

            foreach (Enemy enemy in GameManager.Instance.Enemies)
            {
                _posX += 3;
                enemy.X = _posX;
                enemy.Y = _posY;

                if (_posX % 30 == 0)
                {
                    _posX = 0;
                    _posY += 3;
                }
                enemy.Spawn();
            }
        }

        public GroupEnemies()
        {

        }
    }
}
