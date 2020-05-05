//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Player Class of Spicy Invaders

using System;

namespace SpicyInvaders
{
	/// <summary>
	/// Player Class
	/// </summary>
	public class Player : Character
	{
		private Vector2D _barrelOffset = new Vector2D(0, 1);
		private bool _isAlive = true;
		private bool _canShoot = true;
		private const int SHOOT_DELAY = 10;
		private int _nextShoot = 0;

		public bool IsAlive => _isAlive;

		/// <summary>
		/// Player Constructor
		/// </summary>
		public Player(Vector2D position) : base(position, 'A', ConsoleColor.Cyan,
			GameManager.Instance.Difficulty == GameManager.GameDifficulty.Easy ? 3 : 1)
		{
			Console.SetCursorPosition(position.X, position.Y);
			Draw();
		}

		/// <summary>
		/// Destroys the Player
		/// </summary>
		public override void Destroy()
		{
			ErasePicture();
			GameManager.Instance.RemoveItem(this);
		}

		/// <summary>
		/// Update Player
		/// </summary>
		/// <param name="direction"></param>
		public override void Update(int tick)
		{
			if (tick > _nextShoot)
			{
				_canShoot = true;
			}

			switch (GameManager.Instance.Input.Key)
			{
				case ConsoleKey.LeftArrow:
				{
					if (_position.X > 0)
					{
						UpdatePos(-1);
					}

					break;
				}
				case ConsoleKey.RightArrow:
				{
					if (_position.X < Console.WindowWidth - 1)
					{
						UpdatePos(1);
					}

					break;
				}
				case ConsoleKey.Spacebar:
				{
					if (_canShoot)
					{
						GameManager.Instance.Bullets.Add(new Bullet(_position + _barrelOffset, Direction.Up,
							ConsoleColor.DarkMagenta, 2));
						_canShoot = false;
						_nextShoot = tick + SHOOT_DELAY;
					}

					break;
				}
				case ConsoleKey.Escape:
				{
					// Pause
					Console.Clear();
					GameManager.Instance.WindowSize = new Vector2D(200, 50);
					GameManager.Instance.CurrentMenu = GameManager.Instance.Menus[4];
					GameManager.Instance.State = GameManager.GameManagerState.Pause;
					return;
				}
			}

			// Display life's count
			Console.SetCursorPosition(GameManager.Instance.WindowSize.X - 20, 3);
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.Write("Life : " + _life);

			// Display score in the middle
			Console.SetCursorPosition(GameManager.Instance.WindowSize.X / 2 - 10, 3);
			Console.Write("Score : " + GameManager.Instance.Score);
			Console.ResetColor();

			Draw();
		}

		/// <summary>
		/// Makes the player lose some life
		/// </summary>
		/// <param name="loss">the number of life to remove</param>
		/// <returns>true if dead</returns>
		public override bool LoseLife(int loss)
		{
			_life -= loss;
			if (_life > 0)
			{
				return false;
			}

			GameOver();
			return true;
		}

		/// <summary>
		/// Generate the game over interface
		/// </summary>
		/// <param name="score">Player's score</param>
		public void GameOver()
		{
			_isAlive = false;
			Console.Clear();
			GameManager.Instance.WindowSize = new Vector2D(200, 50);
			GameOver gameOverMenu = (GameOver) GameManager.Instance.Menus[5];
			// Set the score
			gameOverMenu.Score = GameManager.Instance.Score;
			GameManager.Instance.CurrentMenu = gameOverMenu;
			GameManager.Instance.State = GameManager.GameManagerState.GameOver;
		}

		/// <summary>
		/// Update player's position
		/// </summary>
		/// <param name="move">Movement</param>
		private void UpdatePos(int move)
		{
			ErasePicture();
			_position.X += move;
		}
	}
}