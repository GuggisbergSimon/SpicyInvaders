//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : GameManager Class of Spicy Invaders

using System;
using System.Media;
using System.Collections.Generic;
using System.Threading;

namespace SpicyInvaders
{
	/// <summary>
	/// Manager handling the correct execution of the game
	/// </summary>
	public class GameManager
	{
		/// <summary>
		/// Enum to know the state of the game manager
		/// </summary>
		public enum GameManagerState
		{
			MainMenu,
			MainGame,
			Pause,
			GameOver
		}

		/// <summary>
		/// Enum for the different difficulties
		/// </summary>
		public enum GameDifficulty
		{
			Easy,
			Normal,
			Hard
		}

		/// <summary>
		/// singleton for GameManager
		/// </summary>
		public static GameManager Instance { get; private set; }

		private GroupEnemies _groupEnemies;
		private const int DELTA_TIME = 10;
		private Random _random = new Random();
		private ConsoleKeyInfo _input;
		private GameManagerState _state = GameManagerState.MainMenu;
		private GameDifficulty _difficulty = GameDifficulty.Easy;
		private Vector2D _windowSize = new Vector2D(200, 58);
		private int _tick = 1;

		private List<Bullet> _bulletsToDestroy = new List<Bullet>();
		private List<Enemy> _enemiesToDestroy = new List<Enemy>();

		public Vector2D WindowSize
		{
			get { return _windowSize; }
			set { _windowSize = value; }
		}
		public int Score { get; set; } = 0;

		/// <summary>
		/// Getter of Player
		/// </summary>
		public Player Player { get; private set; }

		/// <summary>
		/// Getter of Random
		/// </summary>
		public Random Random { get; } = new Random();

		/// <summary>
		/// Getter of Enemies
		/// </summary>
		public List<Enemy> Enemies { get; } = new List<Enemy>();

		/// <summary>
		/// Getter of Bullets
		/// </summary>
		public List<Bullet> Bullets { get; } = new List<Bullet>();

		/// <summary>
		/// Getter-Setter of Menus
		/// </summary>
		public List<Menu> Menus { get; } = new List<Menu>();

		/// <summary>
		/// Getter-Setter of MusicSound
		/// </summary>
		public SoundPlayer MusicSound { get; private set; }

		/// <summary>
		/// Getter-Setter of CurrentMenu
		/// </summary>
		public Menu CurrentMenu { get; set; }

		/// <summary>
		/// Getter of current Input
		/// </summary>
		public ConsoleKeyInfo Input { get; set; }

		/// <summary>
		/// Gets-Sets the state of the GameManager
		/// </summary>
		public GameManagerState State { get; set; } = GameManagerState.MainMenu;

		/// <summary>
		/// Gets-Sets the difficulty of the game
		/// </summary>
		public GameDifficulty Difficulty { get; set; } = GameDifficulty.Easy;

		/// <summary>
		/// Default constructor of GameManager
		/// </summary>
		public GameManager()
		{
			//singleton setup
			if (Instance == null && Instance != this)
			{
				Instance = this;
			}
		}

		/// <summary>
		/// Setups the game
		/// </summary>
		public void Start()
		{
			Console.CursorVisible = false;
			Console.SetWindowSize(_windowSize.X, _windowSize.Y);

			// SOUND
			MusicSound = new SoundPlayer(@"..\..\Sound\music.wav");
			MusicSound.PlayLooping();

			SetupMenu();
		}

		/// <summary>
		/// Runs the game
		/// </summary>
		public void Run()
		{
			Console.Clear();

			while (true)
			{
				var stopWatch = System.Diagnostics.Stopwatch.StartNew();

				if (Console.KeyAvailable)
				{
					Input = Console.ReadKey(true);
				}
				else
				{
					Input = new ConsoleKeyInfo();
				}


				switch (State)
				{
					case GameManagerState.MainMenu:
					case GameManagerState.Pause:
					case GameManagerState.GameOver:
					{
						LoadMenu();
						break;
					}
					case GameManagerState.MainGame:
					{
						MainGame();
						break;
					}
					default:
					{
						break;
					}
				}

				//Clean the destroyed objects
				foreach (var enemy in _enemiesToDestroy)
				{
					Enemies.Remove(enemy);
				}

				foreach (var bullet in _bulletsToDestroy)
				{
					Bullets.Remove(bullet);
				}

				_enemiesToDestroy.Clear();
				_bulletsToDestroy.Clear();

				stopWatch.Stop();
				if (Convert.ToInt32(stopWatch.ElapsedMilliseconds) < DELTA_TIME)
				{
					Thread.Sleep(DELTA_TIME - Convert.ToInt32(stopWatch.ElapsedMilliseconds));
				}

				_tick++;
			}
		}

		/// <summary>
		/// Loop of the game
		/// </summary>
		private void MainGame()
		{
			_groupEnemies.Update(_tick);

			foreach (var bullet in Bullets)
			{
				bullet.Update(_tick);
			}

			Player.Update(_tick);
			if (!Player.IsAlive)
			{
				Console.Clear();
			}
		}

		/// <summary>
		/// Setup the main game
		/// </summary>
		public void SetupMainGame()
		{
			Score = 0;
			Player = new Player(new Vector2D(35, 35));
			Enemies.Clear();
			Bullets.Clear();
			_groupEnemies = new GroupEnemies(Vector2D.Identity * 5, Vector2D.Identity * 5, Vector2D.Right,
				Direction.Right, 6);
		}

		/// <summary>
		/// Called one time in the Start method and setup the main menus
		/// </summary>
		private void SetupMenu()
		{
			// MAIN MENU
			string[] stringMenuNames = {"Play", "Settings", "Highscore", "About", "Quit"};
			Menus.Add(new Menu(stringMenuNames, "Main menu", _windowSize.X, _windowSize.Y));

			// SETTINGS MENU
			string[] stringMenuNames1 = {"Difficulty :    Easy", "Mute :          disabled", "Back"};
			Menus.Add(new Menu(stringMenuNames1, "Settings", _windowSize.X, _windowSize.Y));

			// HIGHSCORE AND ABOUT MENU
			string[] stringMenuNames2 = {"Back"};
			Menus.Add(new Menu(stringMenuNames2, "Highscore", _windowSize.X, _windowSize.Y));
			Menus.Add(new Menu(stringMenuNames2, "About", _windowSize.X, _windowSize.Y));

			// PAUSE MENU
			string[] stringMenuNames3 = {"Resume", "Mute :          disabled", "Back to main menu"};
			Menus.Add(new Menu(stringMenuNames3, "Pause", _windowSize.X, _windowSize.Y));

			// GAME OVER MENU
			string[] stringMenuNames4 = new string[] { };
			Menus.Add(new GameOver(stringMenuNames4, "", _windowSize.X, _windowSize.Y));

			// Set the default menu onto the main menu
			CurrentMenu = Menus[0];
			Menu._muteState = MuteState.Disabled;
		}

		/// <summary>
		/// Load the current menu
		/// </summary>
		private void LoadMenu()
		{
			// Draw the main menu with a full capital name
			CurrentMenu.LoadPage(CurrentMenu.Name.ToUpper());
		}

		/// <summary>
		/// Adds an object to be destroyed
		/// </summary>
		/// <param name="objectToDestroy"></param>
		public void RemoveItem<T>(T objectToDestroy)
		{
			if (typeof(T) == typeof(Bullet))
			{
				_bulletsToDestroy.Add(objectToDestroy as Bullet);
			}
			else if (typeof(T) == typeof(Enemy))
			{
				_enemiesToDestroy.Add(objectToDestroy as Enemy);
			}
		}
	}
}