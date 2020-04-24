namespace SpicyInvaders
{
	public abstract class Character: SimpleObject
	{
		protected int _life;

		protected Character(Vector2D position, char visual, int life) : base(position, visual)
		{
			_life = life;
		}
		public abstract bool LoseLife(int loss);
	}
}