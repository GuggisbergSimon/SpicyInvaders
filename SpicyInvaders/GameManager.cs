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
        /// <summary>
        /// enum for the current GameManagerState
        /// </summary>
        public enum GameManagerState
        {
            MainMenu,
            MainGame,
            Pause,
            Score
        }

        /// <summary>
        /// ATTRIBUTES
        /// </summary>

        // singleton for easier access to the instance of the GameManager
        public static GameManager Instance { get; private set; }

        private List<SimpleObject> enemiesAndBullets = new List<SimpleObject>();
        private Player _player;
        private GroupEnemies _grpEnemies;
        private const int DELTA_TIME = 10;
        private long tick = 1;
        private Menu _menu;
        private Menu _settingsMenu;
        private Random _random = new Random();
        private ConsoleKeyInfo _input;
        private GameManagerState _state = GameManagerState.MainMenu;
        private readonly Vector2D _windowSize = new Vector2D(200, 60);
        private List<Menu> _menus = new List<Menu>();
        private Menu _currentMenu;
        private List<SimpleObject> _objectsToDestroy = new List<SimpleObject>();

        /// <summary>
        /// Getter of Player
        /// </summary>
        public Player Player
        {
            get { return _player; }
        }

        /// <summary>
        /// Getter of EnemiesAndBullets
        /// </summary>
        public List<SimpleObject> EnemiesAndBullets
        {
            get { return enemiesAndBullets; }
        }

        /// <summary>
        /// Getter-Setter of Menus
        /// </summary>
        public List<Menu> Menus
        {
            get { return _menus; }
            set { _menus = value; }
        }

        /// <summary>
        /// Getter-Setter of CurrentMenu
        /// </summary>
        public Menu CurrentMenu
        {
            get { return _currentMenu; }
            set { _currentMenu = value; }
        }

        /// <summary>
        /// Getter of current Input
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
        }

        /// <summary>
        /// Setups the game
        /// </summary>
        public void Start()
        {
            Console.CursorVisible = false;
            Console.SetWindowSize(_windowSize.X, _windowSize.Y);

            // Create all the menu objects
            string[] stringMenuNames = {"Play", "Settings", "Highscore", "About", "Quit"};
            // Name of the buttons and the name of the menu
            Menus.Add(new Menu(stringMenuNames, ""));

            string[] stringMenuNames1 = {"Sound", "Mute", "Back"};
            Menus.Add(new Menu(stringMenuNames1, "Settings"));

            string[] stringMenuNames2 = {"Back"};
            Menus.Add(new Menu(stringMenuNames2, "Highscore"));
            Menus.Add(new Menu(stringMenuNames2, "About"));

            _currentMenu = Menus[0];
            _player = new Player(35, 35);
            enemiesAndBullets.Add(new Enemy(new Vector2D(35, 10)));
        }

        /// <summary>
        /// Runs the game
        /// </summary>
        public void Run()
        {
            Console.Clear();
            _grpEnemies = new GroupEnemies(5, 5);
            _grpEnemies.SpawnEnemies();

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

                // todo remove 3 next lines (test for fps purposes)
                // Console.SetCursorPosition(10, 10);
                // Console.WriteLine(_random.Next(10,100));
                // Console.SetCursorPosition(_player.PlayerX + 1, _player.PlayerY);
                switch (_state)
                {
                    case GameManagerState.MainMenu:
                    {
                        LoadMenu();
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

                //Clean the destroyed objects
                foreach (var objToDestroy in _objectsToDestroy)
                {
                    enemiesAndBullets.Remove(objToDestroy);
                }

                _objectsToDestroy.Clear();

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
            foreach (var obj in enemiesAndBullets)
            {
                obj.Update();
            }

            _player.Update();
        }

        /// <summary>
        /// Load a menu
        /// </summary>
        private void LoadMenu()
        {
            // Draw the main menu with his title
            _currentMenu.LoadPage(_currentMenu.Name.ToUpper());
        }

        /// <summary>
        /// Adds an object to be destroyed
        /// </summary>
        /// <param name="objectToDestroy"></param>
        public void RemoveItem(SimpleObject objectToDestroy)
        {
            _objectsToDestroy.Add(objectToDestroy);
        }
    }
}