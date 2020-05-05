//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Enemy Class of Spicy Invaders


using System;
using System.Collections.Generic;

namespace SpicyInvaders
{
	/// <summary>
	/// GroupEnemies class
	/// </summary>
	public class GroupEnemies
	{
		private Direction _direction;
		private int _speed;
		private const int SPEED_MAX = 3;

		/// <summary>
		/// GroupEnemies Constructor
		/// </summary>
		/// <param name="startPos">the top left position of the group</param>
		/// <param name="size">the size of the group</param>
		/// <param name="padding">the padding between each member of the group</param>
		/// <param name="direction">the direction the group is moving at start</param>
		/// <param name="speed">the sped the group is moving</param>
		public GroupEnemies(Vector2D startPos, Vector2D size, Vector2D padding, Direction direction, int speed)
		{
			_direction = direction;
			_speed = speed;
			for (int i = 0; i < size.X; i++)
			{
				for (int j = 0; j < size.Y; j++)
				{
					GameManager.Instance.Enemies.Add(new Enemy(new Vector2D(startPos.X + i + i * padding.X,
						startPos.Y + j + j * padding.Y), 100));
				}
			}
		}

		/// <summary>
		/// Handles the movement of the enemies
		/// </summary>
		public void Update(int tick)
		{
			List<Enemy> enemies = GameManager.Instance.Enemies;
			if (enemies.Count < 1 || tick % _speed != 0)
			{
				return;
			}

			// set the speed in function of left ennemies
			if (_speed > SPEED_MAX)
			{
				_speed = enemies.Count / 5;
			}

			//find rightest/leftest enemy by comparing positions
			bool goingRight = _direction == Direction.Right;
			int indexMaxMin = 0;
			for (int i = 1; i < enemies.Count; i++)
			{
				if (!goingRight && enemies[i].Position.X < enemies[indexMaxMin].Position.X ||
				    goingRight && enemies[i].Position.X > enemies[indexMaxMin].Position.X)
				{
					indexMaxMin = i;
				}
			}

			//checks for borders
			Vector2D nextPos = Vector2D.Right * (goingRight ? 1 : -1);
			if (goingRight && enemies[indexMaxMin].Position.X + nextPos.X >= Console.WindowWidth &&
			    enemies[indexMaxMin].Position.Y + nextPos.Y < Console.WindowHeight ||
			    !goingRight && enemies[indexMaxMin].Position.X + nextPos.X < 0 &&
			    enemies[indexMaxMin].Position.Y + nextPos.Y < Console.WindowHeight)
			{
				nextPos = Vector2D.Up;
				_direction = goingRight ? Direction.Left : Direction.Right;
			}

			foreach (var enemy in GameManager.Instance.Enemies)
			{
				enemy.ErasePicture();
				if ((enemy.Position + nextPos).Y >= GameManager.Instance.Player.Position.Y)
				{
					GameManager.Instance.Player.GameOver();
					nextPos = Vector2D.Zero;
				}

				enemy.Position += nextPos;
				enemy.Update(tick);
			}

			// Display ennemies left in the up corner left
			Console.SetCursorPosition(3, 3);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("Ennemies left : ");
			// Delete the old number
			Console.Write("  \b\b");
			Console.Write(GameManager.Instance.Enemies.Count);
			Console.ResetColor();
		}
	}
}