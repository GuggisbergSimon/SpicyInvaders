//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Enemy Class of Spicy Invaders


using System;

namespace SpicyInvaders
{
	public class GroupEnemies
	{
		private int _speed;
		/// <summary>
		/// GroupEnemies Constructor
		/// </summary>
		/// <param name="startPos">the top left position of the group</param>
		/// <param name="size">the size of the group</param>
		/// <param name="padding">the padding between each member of the group</param>
		public GroupEnemies(Vector2D startPos, Vector2D size, Vector2D padding, int speed)
		{
			_speed = speed;
			for (int i = 0; i < size.X; i++)
			{
				for (int j = 0; j < size.Y; j++)
				{
					GameManager.Instance.Enemies.Add(new Enemy(new Vector2D(startPos.X + i + i * padding.X,
						startPos.Y + j + j * padding.Y)));
				}
			}
		}

		/// <summary>
		/// Handles the movement of the enemies
		/// </summary>
		public void Update(int tick)
		{
			foreach (var enemy in GameManager.Instance.Enemies)
			{
				if (tick % _speed == 0)
				{
					enemy.ErasePicture();
					enemy.Position += Vector2D.Right * 2;
				}

				enemy.Update(tick);
			}
		}
	}
}