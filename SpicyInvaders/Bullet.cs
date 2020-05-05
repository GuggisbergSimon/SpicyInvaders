//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Bullet Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
	/// <summary>
	/// Bullet Class
	/// </summary>
	public class Bullet : SimpleObject
	{
		private ConsoleColor _color;
		private readonly int _speed;
		private const int STRENGTH = 1;
		private bool _isMoving = true;

		/// <summary>
		/// Direction getter
		/// </summary>
		private Direction Direction { get; }

		/// <summary>
		/// Bullet Constructor
		/// </summary>
		/// <param name="pos"></param>
		/// <param name="dir"></param>
		/// <param name="color"></param>
		/// <param name="speed"></param>
		public Bullet(Vector2D pos, Direction dir, ConsoleColor color, int speed) : base(pos, '!', color)
		{
			Direction = dir;
			_speed = speed;
		}

		/// <summary>
		/// Destroys the Bullet
		/// </summary>
		public override void Destroy()
		{
			ErasePicture();
			GameManager.Instance.RemoveItem(this);
		}

		/// <summary>
		/// Update Bullet
		/// </summary>
		public override void Update(int tick)
		{
			if (!_isMoving || tick % _speed != 0) return;
			switch (Direction)
			{
				case Direction.Up when _position.Y > 0:
					UpdatePos(-Vector2D.Up);
					break;
				case Direction.Down when _position.Y < Console.WindowHeight - 1:
					UpdatePos(Vector2D.Up);
					break;
				case Direction.Right when _position.X < Console.WindowWidth - 1:
					UpdatePos(Vector2D.Right);
					break;
				case Direction.Left when _position.X > 0:
					UpdatePos(-Vector2D.Right);
					break;
				default:
					_isMoving = false;
					Destroy();
					break;
			}
		}

		private void UpdatePos(Vector2D move)
		{
			ErasePicture();
			_position += move;
			Draw();

			//When a bullet meets a bullet
			foreach (var bullet in GameManager.Instance.Bullets)
			{
				if (bullet.Position != _position || Direction == bullet.Direction || bullet == this) continue;
				bullet.Destroy();
				Destroy();
			}

			//When a bullet meets an enemy
			foreach (var enemy in GameManager.Instance.Enemies)
			{
				if (enemy.Position != _position || Direction != Direction.Up) continue;
				enemy.LoseLife(STRENGTH);
				enemy.Destroy();
				Destroy();
			}

			//When a bullets meet the player
			if (GameManager.Instance.Player.Position == _position && Direction == Direction.Down)
			{
				Destroy();
				GameManager.Instance.Player.LoseLife(STRENGTH);
			}
		}
	}
}