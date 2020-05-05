//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Main Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
	/// <summary>
	/// Program class
	/// </summary>
	public class Program
	{
		/// <summary>
		/// Main function of the game
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			GameManager gameManager = new GameManager();
			gameManager.Start();
			gameManager.Run();
		}
	}
}