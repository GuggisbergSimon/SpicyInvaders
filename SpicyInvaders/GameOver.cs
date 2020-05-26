//Authors       : HDN, KBY, YFA & SGG
//Date          : 24.04.2020
//Location      : ETML
//Description   : GameOver Class of Spicy Invaders

using System;
using System.Collections.Generic;

namespace SpicyInvaders
{
	/// <summary>
	/// GameOver menu
	/// </summary>
	public class GameOver : Menu
	{
		private const string SCORE_TITLE = "YOUR SCORE";
		private const string NAME_TITLE = "TYPE YOUR NAME THEN PRESS ENTER";
		private const string NAME_CAUTION = "CANNOT BE EMPTY OR HIGHER THAN 20 CHARACTERS";

		private readonly string[] nameRectangle =
		{
			"╔═════════════════════════╗",
			"║                         ║",
			"╚═════════════════════════╝"
		};

		private List<char> _playerNames;

		/// <summary>
		/// Score Getter-Setter
		/// </summary>
		public int Score { get; set; }

		/// <summary>
		/// GameOver constructor
		/// </summary>
		/// <param name="buttonNames"></param>
		/// <param name="aName"></param>
		/// <param name="consoleWidth"></param>
		/// <param name="consoleHeight"></param>
		public GameOver(string[] buttonNames, string aName, int consoleWidth, int consoleHeight) : base(buttonNames,
			aName, consoleWidth, consoleHeight)
		{
			_playerNames = new List<char>();
			_title = new string[]
			{
				" d888b   .d8b.  .88b  d88. d88888b    .d88b.  db    db d88888b d8888b.",
				"88' Y8b d8' `8b 88'YbdP`88 88'       .8P  Y8. 88    88 88'     88  `8D",
				"88      88ooo88 88  88  88 88ooooo   88    88 Y8    8P 88ooooo 88oobY'",
				"88  ooo 88~~~88 88  88  88 88~~~~~   88    88 `8b  d8' 88~~~~~ 88`8b",
				"88. ~8~ 88   88 88  88  88 88.       `8b  d8'  `8bd8'  88.     88 `88.",
				" Y888P  YP   YP YP  YP  YP Y88888P    `Y88P'     YP    Y88888P 88   YD"
			};
		}

		/// <summary>
		/// Draw the score and waiting the player to type his name
		/// </summary>
		protected override void DrawOptions()
		{
			string score = Convert.ToString(Score);

			Console.CursorTop += 3; // Too close of the menu title
			Console.CursorVisible = true;

			// Score title
			Console.ForegroundColor = ConsoleColor.Green;
			Console.CursorLeft = Console.WindowWidth / 2 - SCORE_TITLE.Length / 2;
			Console.WriteLine(SCORE_TITLE + "\n");

			// Score
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.CursorLeft = Console.WindowWidth / 2 - score.Length / 2;
			Console.WriteLine(score + "\n\n\n");

			// Name title
			Console.ForegroundColor = ConsoleColor.Green;
			Console.CursorLeft = Console.WindowWidth / 2 - NAME_TITLE.Length / 2;
			Console.WriteLine(NAME_TITLE + "\n");

			// Name rectangle
			Console.ForegroundColor = ConsoleColor.White;
			foreach (string line in nameRectangle)
			{
				Console.CursorLeft = Console.WindowWidth / 2 - line.Length / 2;
				Console.WriteLine(line);
			}

			// Name caution
			Console.Write("\n");
			Console.ForegroundColor = ConsoleColor.Red;
			Console.CursorLeft = Console.WindowWidth / 2 - NAME_CAUTION.Length / 2;
			Console.WriteLine(NAME_CAUTION + "\n");

			// Name
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.CursorTop -= 5; // get back in the rectangle
			Console.CursorLeft = Console.WindowWidth / 2 - nameRectangle[0].Length / 2 + 2;
		}

		protected override void KeyManager()
		{
			// Can write characters
			GameManager.Instance.Input = Console.ReadKey(false);
			switch (GameManager.Instance.Input.Key)
			{
				// Loop for the selection of an option by pressing enter
				case ConsoleKey.Enter when _playerNames.Count != 0:
				{
					Console.CursorVisible = false;
					HighscoreDB.WriteScore(new string(_playerNames.ToArray()).Trim(), Score);
					_playerNames.Clear();
					_redraw = true;
					// Clear because we change the menu page
					Console.Clear();
					GameManager.Instance.CurrentMenu = GameManager.Instance.Menus[0];
					GameManager.Instance.State = GameManager.GameManagerState.MainMenu;
					break;
				}
				case ConsoleKey.Enter:
				{
					Console.CursorLeft = Console.WindowWidth / 2 - nameRectangle[0].Length / 2 + 2;
					break;
				}
				case ConsoleKey.Backspace when _playerNames.Count != 0:
				{
					_playerNames.RemoveAt(_playerNames.Count - 1);
					Console.Write(" \b");
					break;
				}
				case ConsoleKey.Backspace:
				{
					// Stay here
					Console.Write(" ");
					break;
				}
				default:
				{
					if (_playerNames.Count <= 22)
					{
						_playerNames.Add(GameManager.Instance.Input.KeyChar);
						GameManager.Instance.Input.Key.ToString().ToUpper();
					}
					else
					{
						Console.Write("\b \b");
					}

					break;
				}
			}
		}
	}
}