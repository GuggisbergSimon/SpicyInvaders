//Authors       : HDN, KBY, YFA & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : GameManager Class of Spicy Invaders

using System;
using System.Collections.Generic;
using System.Threading;

namespace SpicyInvaders
{
    /// <summary>
    /// Manager handling the correct execution of the game
    /// </summary>
    public class GameManager
    {
        // singleton for easier access to the instance of the GameManager
        public static GameManager Instance { get; private set; }
        private List<Enemy> _enemies = new List<Enemy>();
        private List<Bullet> _bullets = new List<Bullet>();
        private Player _player;
        private GroupEnemies _grpEnemies;
        private const int DELTA_TIME = 10;
        private long tick = 1;
        private Menu _menu;
        private Menu _settingsMenu;
        private Random _random = new Random();

        /// <summary>
        /// Gets the player
        /// </summary>
        public Player Player
        {
            get { return _player; }
        }

        /// <summary>
        /// Gets the list of enemies
        /// </summary>
        public List<Enemy> Enemies
        {
            get { return _enemies; }
        }

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

            _player = new Player(50, 35);
        }

        /// <summary>
        /// Starts the game and runs it
        /// </summary>
        public void Start()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 50);

            // Create the main menu object
            string[] stringMenuNames = { "Play", "Settings", "Highscore", "About", "Quit" };
            _menu = new Menu(stringMenuNames);
            Menu.listMenus.Add(_menu);
        }

        /// <summary>
        /// Load the game
        /// </summary>
        public void MainGame()
        {
            _grpEnemies = new GroupEnemies(5,5);
            _grpEnemies.SpawnEnemies();

            while (true)
            {
                var stopWatch = System.Diagnostics.Stopwatch.StartNew();
                // main loop of the game

                //if(tick % 100 == 0)
                //{
                //    _grpEnemies.Update();
                //}

                foreach (var bullet in _bullets)
                {
                    // todo update here
                }

                // todo update player
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo input = Console.ReadKey(true);

                    switch (input.Key)
                    {
                        case ConsoleKey.LeftArrow:
                            _player.Update(Direction.Left);
                            break;
                        case ConsoleKey.RightArrow:
                            _player.Update(Direction.Right);
                            break;
                        default:
                            break;
                    }
                }

                // todo remove
                Console.SetCursorPosition(80, 40);
                Console.WriteLine(_random.Next(0,1001));
                Console.SetCursorPosition(80, 41);
                Console.WriteLine(tick += 1);
                Console.SetCursorPosition(_player.X + 1, _player.Y);

                stopWatch.Stop();
                if (Convert.ToInt32(stopWatch.ElapsedMilliseconds) < DELTA_TIME)
                {
                    Thread.Sleep(DELTA_TIME - Convert.ToInt32(stopWatch.ElapsedMilliseconds));
                }
            }
        }

        /// <summary>
        /// Load the main menu
        /// </summary>
        public void MainMenu()
        {
            Console.Clear();

            // Display the default menu
            _menu.DrawTitle();
            // Display all the option buttons
            _menu.DrawOptions();
            // Enable the key manager of the menu
            _menu.KeyManager();
        }
    }
}
