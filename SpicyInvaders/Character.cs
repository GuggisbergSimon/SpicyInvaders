using System;

namespace SpicyInvaders
{
	public abstract class Character : SimpleObject
	{
		protected int _life;

		public int Life
		{
			get { return _life; }
		}


		/// <summary>
		/// Character constructor
		/// </summary>
		/// <param name="position"></param>
		/// <param name="visual"></param>
		/// <param name="color"></param>
		/// <param name="life"></param>
		protected Character(Vector2D position, char visual, ConsoleColor color, int life) : base(position, visual,
			color)
		{
			_life = life;
		}

		/// <summary>
		/// Lose a given number of life
		/// </summary>
		/// <param name="loss"></param>
		/// <returns></returns>
		public abstract bool LoseLife(int loss);
	}
}