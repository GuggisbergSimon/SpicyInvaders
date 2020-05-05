//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Enemy Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
	/// <summary>
	/// Enemy class
	/// </summary>
	public class Enemy : Character
	{
		private int _score;

		/// <summary>
		/// Custom Constructor for the object Enemy
		/// </summary>
		/// 
		public Enemy(Vector2D pos, int score) : base(pos, 'O', ConsoleColor.Red, 1)
		{
			_position = pos;
			_score = score;
		}

		/// <summary>
		/// Destroys the Enemy
		/// </summary>
		public override void Destroy()
		{
			ErasePicture();
			GameManager.Instance.Score += _score;
			GameManager.Instance.RemoveItem(this);
			if (GameManager.Instance.Enemies.Count < 2)
			{
				GameManager.Instance.Player.GameOver();
			}
		}

		/// <summary>
		/// Update Enemy
		/// </summary>
		public override void Update(int tick)
		{
			Draw();
			if (GameManager.Instance.Random.Next(60) == 0 || (_position.X == GameManager.Instance.Player.Position.X && GameManager.Instance.Random.Next(2) == 0))
			{

				GameManager.Instance.Bullets.Add(new Bullet(_position, Direction.Down,
					(ConsoleColor) (tick % Enum.GetNames(typeof(ConsoleColor)).Length), 6));
			}
		}

		/// <summary>
		/// Lose a given number of life
		/// </summary>
		/// <param name="loss"></param>
		/// <returns></returns>
		public override bool LoseLife(int loss)
		{
			_life -= loss;
			if (_life > 0) return false;
			Destroy();
			return true;

		}
	}
}