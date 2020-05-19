//Authors       : HDN, KBY, YFA & SGG
//Date          : 10.03.2020
//Location      : ETML
//Description   : Highscore Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
	/// <summary>
	/// Character class
	/// </summary>
	public abstract class Character : SimpleObject
	{
		/// <summary>
		/// the number of life the character has
		/// </summary>
		protected int _life;

		/// <summary>
		/// getter-setter of life
		/// </summary>
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