//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Vector2D Struct of Spicy Invaders

namespace SpicyInvaders
{
	/// <summary>
	/// Vector2D Class
	/// </summary>
	public struct Vector2D
	{
		/// <summary>
		/// Returns a Vector facing Right
		/// </summary>
		public static Vector2D Right => new Vector2D(1, 0);

		/// <summary>
		/// Returns a Vector facing Up
		/// </summary>
		public static Vector2D Up => new Vector2D(0, 1);

		/// <summary>
		/// Returns an Identity Vector
		/// </summary>
		public static Vector2D Identity => new Vector2D(1, 1);

		/// <summary>
		/// Returns a Zero Vector
		/// </summary>
		public static Vector2D Zero => new Vector2D(0, 0);

		/// <summary>
		/// get-set the X-axis
		/// </summary>
		public int X { get; set; }

		/// <summary>
		/// get-set the Y-axis
		/// </summary>
		public int Y { get; set; }

		/// <summary>
		/// Vector2D constructor
		/// </summary>
		/// <param name="x">X-axis</param>
		/// <param name="y">Y-axis</param>
		public Vector2D(int x, int y)
		{
			X = x;
			Y = y;
		}

		/// <summary>
		/// equals operator
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static bool operator ==(Vector2D v1, Vector2D v2)
		{
			return v1.Equals(v2);
		}

		/// <summary>
		/// not equals operator
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static bool operator !=(Vector2D v1, Vector2D v2)
		{
			return !v1.Equals(v2);
		}

		/// <summary>
		/// equals operation
		/// </summary>
		/// <param name="v"></param>
		/// <returns></returns>
		public override bool Equals(object v)
		{
			return v is Vector2D vector2D && this.Equals(vector2D);
		}

		/// <summary>
		/// returns an hashcode
		/// </summary>
		/// <returns></returns>
		public override int GetHashCode()
		{
			unchecked
			{
				return (X * 397) ^ Y;
			}
		}

		private bool Equals(Vector2D other)
		{
			return X == other.X && Y == other.Y;
		}

		/// <summary>
		/// minus operation
		/// </summary>
		/// <param name="v1"></param>
		/// <returns></returns>
		public static Vector2D operator -(Vector2D v1)
		{
			return v1 * -1;
		}

		/// <summary>
		/// addition operation
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static Vector2D operator +(Vector2D v1, Vector2D v2)
		{
			return new Vector2D(v1.X + v2.X, v1.Y + v2.Y);
		}

		/// <summary>
		/// subtraction operation
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="v2"></param>
		/// <returns></returns>
		public static Vector2D operator -(Vector2D v1, Vector2D v2)
		{
			return new Vector2D(v1.X - v2.X, v1.Y - v2.Y);
		}

		/// <summary>
		/// multiplication operation
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="k"></param>
		/// <returns></returns>
		public static Vector2D operator *(Vector2D v1, int k)
		{
			return new Vector2D(v1.X * k, v1.Y * k);
		}

		/// <summary>
		/// division operation
		/// </summary>
		/// <param name="v1"></param>
		/// <param name="k"></param>
		/// <returns></returns>
		public static Vector2D operator /(Vector2D v1, int k)
		{
			return new Vector2D(v1.X / k, v1.Y / k);
		}
	}
}