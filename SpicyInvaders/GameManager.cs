﻿//Authors       : HDN, KBY, YFA & SGG
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
        public enum GameManagerState
        {
            MainMenu,
            MainGame,
            Pause,
            Score
        }

        public enum GameDifficulty
        {
            Easy,
            Normal,
            Hard
        }

        /// <summary>
        /// ATTRIBUTES
        /// </summary>

        // singleton for easier access to the instance of the GameManager
        public static GameManager Instance { get; private set; }

        private List<SimpleObject> _objects = new List<SimpleObject>();
        private Player _player;
        private GroupEnemies _grpEnemies;
        private const int DELTA_TIME = 10;
        private long tick = 1;
        private Menu _menu;
        private Menu _settingsMenu;
        private Random _random = new Random();
        private ConsoleKeyInfo _input;
        private GameManagerState _state = GameManagerState.MainMenu;
        private GameDifficulty _difficulty = GameDifficulty.Easy;
        private readonly Vector2D _windowSize = new Vector2D(200, 60);
        private List<Menu> _menus = new List<Menu>();
        private Menu _currentMenu;
        private SoundPlayer _musicSound;
        private SoundPlayer _shootSound;
        private SoundPlayer _destroySound;
        private List<SimpleObject> _objectsToDestroy = new List<SimpleObject>();

        /// <summary>
        /// PROPERTIES
        /// </summary>
        public Player Player
        {
            get { return _player; }
        }

        public List<SimpleObject> Objects
        {
            get { return _objects; }
        }

        public List<Menu> Menus
        {
            get { return _menus; }
            set { _menus = value; }
        }

        public SoundPlayer Sound
        {
            get { return _musicSound; }
            set { _musicSound = value; }
        }

        public Menu CurrentMenu
        {
            get { return _currentMenu; }
            set { _currentMenu = value; }
        }

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
        /// Gets-Sets the difficulty of the game
        /// </summary>
        public GameDifficulty Difficulty
        {
            get { return _difficulty; }
            set { _difficulty = value; }
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

            // Set the sound
            _shootSound = new SoundPlayer(@"..\..\Sound\fire.wav");
            _destroySound = new SoundPlayer(@"..\..\Sound\destroy.wav");
            _musicSound = new SoundPlayer(@"..\..\Sound\music.wav");
            _musicSound.PlayLooping();

            // Create all the menu objects
            string[] stringMenuNames = {"Play", "Settings", "Highscore", "About", "Quit"};
            // Name of the buttons and the name of the menu
            Menus.Add(new Menu(stringMenuNames, ""));

            string[] stringMenuNames1 = {"Difficulty :    Easy", "Mute :          disabled", "Back"};
            Menus.Add(new Menu(stringMenuNames1, "Settings"));

            string[] stringMenuNames2 = {"Back"};
            Menus.Add(new Menu(stringMenuNames2, "Highscore"));
            Menus.Add(new Menu(stringMenuNames2, "About"));

            _currentMenu = Menus[0];
            _player = new Player(35, 35);
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

                // todo remove 3 next lines (test for fps purposes
                // Console.SetCursorPosition(10, 10);
                // Console.WriteLine(_random.Next(0,101));
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
                foreach (var enemyToDestroy in _objectsToDestroy)
                {
                    _objects.Remove(enemyToDestroy);
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
            foreach (var obj in _objects)
            {
                obj.Update();
                // todo update here
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

        public void RemoveItem(SimpleObject objectToDestroy)
        {
            _objectsToDestroy.Add(objectToDestroy);
        }
    }
}