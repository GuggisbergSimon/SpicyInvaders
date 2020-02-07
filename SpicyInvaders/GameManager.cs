﻿//Authors       : HDN, KBY, YFA & SGG
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
        public enum GameManagerState
        {
            MainMenu,
            MainGame,
            Pause,
            Score
        }

        // singleton for easier access to the instance of the GameManager
        public static GameManager Instance { get; private set; }
        private List<Enemy> _enemies = new List<Enemy>();
        private List<Bullet> _bullets = new List<Bullet>();
        private Player _player;
        private const int DELTA_TIME = 10;
        private Random _random = new Random();
        private ConsoleKeyInfo _input;
        private GameManagerState _state = GameManagerState.MainMenu;
        private readonly Vector2D windowSize = new Vector2D(200, 60);

        // List of all the menus available in Spicy Invaders
        private List<Menu> _menus = new List<Menu>();
        private Menu _settingsMenu;

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
        /// Gets-Sets the menus
        /// </summary>
        public List<Menu> Menus
        {
            get { return _menus; }
            set { _menus = value; }
        }

        /// <summary>
        /// Gets the random source of the game
        /// </summary>
        public Random Random
        {
            get { return _random; }
        }

        /// <summary>
        /// Gets the WindowSize
        /// </summary>
        public Vector2D WindowSize
        {
            get { return windowSize; }
        }

        /// <summary>
        /// Gets the current input
        /// </summary>
        public ConsoleKeyInfo Input
        {
            get { return _input; }
        }

        /// <summary>
        /// Gets-Sets the state of the GameManager
        /// </summary>
        public GameManagerState State
        {
            get { return _state; }
            set { _state = value; }
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

            _player = new Player(1, 1);
        }

        /// <summary>
        /// Setups the game
        /// </summary>
        public void Start()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(windowSize.X, windowSize.Y);

            // Create the main menu object
            string[] stringMenuNames = {"Play", "Settings", "Highscore", "About", "Quit"};
            Menus.Add(new Menu(stringMenuNames));
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
                    _input = Console.ReadKey(true);
                }
                else
                {
                    _input = new ConsoleKeyInfo();
                }

                // todo remove 3 next lines (test for fps purposes
                // Console.SetCursorPosition(10, 10);
                // Console.WriteLine(_random.Next(0,101));
                // Console.SetCursorPosition(_player.PlayerX + 1, _player.PlayerY);
                switch (_state)
                {
                    case GameManagerState.MainMenu:
                    {
                        MainMenu();
                        break;
                    }
                    case GameManagerState.MainGame:
                    {
                        MainGame();
                        break;
                    }
                    case GameManagerState.Pause:
                    {
                        // todo pause menu here
                        break;
                    }
                    case GameManagerState.Score:
                    {
                        // todo score menu here
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }

                stopWatch.Stop();
                if (Convert.ToInt32(stopWatch.ElapsedMilliseconds) < DELTA_TIME)
                {
                    Thread.Sleep(DELTA_TIME - Convert.ToInt32(stopWatch.ElapsedMilliseconds));
                }
            }
        }

        /// <summary>
        /// loop of the game
        /// </summary>
        private void MainGame()
        {
            foreach (var enemy in _enemies)
            {
                // todo update here
            }

            foreach (var bullet in _bullets)
            {
                // todo update here
            }

            _player.Update();
        }

        /// <summary>
        /// Load the main menu
        /// </summary>
        private void MainMenu()
        {
            // Draw the main menu without title
            Menus[0].LoadPage("");
        }
    }
}