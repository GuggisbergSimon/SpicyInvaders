//Authors       : HDN, YFA, KBY & SGG
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
        private const int DELTA_TIME = 10;
        private MainMenu _menu;

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
            if (Instance != null && Instance != this)
            {
                Instance = this;
            }
        }

        /// <summary>
        /// Starts the game and runs it
        /// </summary>
        public void Start()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(100, 50);

            // Create the main menu
            _menu = new MainMenu();
        }

        /// <summary>
        /// Load the game
        /// </summary>
        public void MainGame()
        {
            while (true)
            {
                var stopWatch = System.Diagnostics.Stopwatch.StartNew();
                // main loop of the game
                foreach (var enemy in _enemies)
                {
                    // todo update here
                }
                foreach (var bullet in _bullets)
                {
                    // todo update here
                }

                // todo update player

                stopWatch.Stop();
                if (Convert.ToInt32(stopWatch.ElapsedMilliseconds) > DELTA_TIME)
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
            // Display the menu
            _menu.Refresh(true);

            bool selectOption = false;

            // Loop for the selection of an option by pressing enter
            while (!selectOption)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        // false = move down
                        _menu.Refresh(false);
                        break;
                    case ConsoleKey.UpArrow:
                        // true = move up
                        _menu.Refresh(true);
                        break;
                    case ConsoleKey.Enter:
                        // leave the loop
                        selectOption = true;

                        // What button is selected
                        switch (_menu.SelectedIndex)
                        {
                            case 0:
                                // do nothing just go on to the next loop
                                break;
                            case 1:
                                // TODO : SETTINGS PAGE
                                break;
                            case 2:
                                // TODO : HIGHSCORE PAGE
                                break;
                            case 3:
                                // TODO : ABOUT PAGE
                                break;
                            case 4:
                                Environment.Exit(0);
                                break;
                            default:
                                break;
                        }

                        break;
                    default:
                        break;
                }
            }
        }
    }
}
