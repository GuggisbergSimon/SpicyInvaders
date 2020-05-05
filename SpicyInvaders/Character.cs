using System;

namespace SpicyInvaders
{
	public abstract class Character : SimpleObject
	{
		protected int _life;

		protected Character(Vector2D position, char visual, ConsoleColor color, int life) : base(position, visual,
			color)
		{
			_life = life;
		}

		public abstract bool LoseLife(int loss);
	}
}