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
            Score
        }

        public enum GameDifficulty
        {
            Easy = 3,
            Normal = 2,
            Hard = 1
        }

        /// <summary>
        /// ATTRIBUTES
        /// </summary>

        // singleton for easier access to the instance of the GameManager
        public static GameManager Instance { get; private set; }

        private List<Bullet> _bullets = new List<Bullet>();
        private List<Enemy> _enemies = new List<Enemy>();
        private Player _player;
        private GroupEnemies _grpEnemies;
        private const int DELTA_TIME = 10;
        private int tick = 1;
        private Random _random = new Random();
        private ConsoleKeyInfo _input;
        private GameManagerState _state = GameManagerState.MainMenu;
        private GameDifficulty _difficulty = GameDifficulty.Easy;
        private readonly Vector2D _windowSize = new Vector2D(200, 58);
        private List<Menu> _menus = new List<Menu>(); // 0 : Main menu, 1 : Settings menu, 2 : Highscore menu, 3 : About menu, 4 : Pause menu
        private Menu _currentMenu;
        private SoundPlayer _musicSound;
        private List<Bullet> _bulletsToDestroy = new List<Bullet>();
        private List<Enemy> _enemiesToDestroy = new List<Enemy>();

        /// <summary>
        /// Getter of Player
        /// </summary>
        public Player Player => _player;
        
        /// <summary>
        /// Getter of Enemies
        /// </summary>
        public List<Enemy> Enemies => _enemies;
        
        /// <summary>
        /// Getter of Bullets
        /// </summary>
        public List<Bullet> Bullets => _bullets;
        
        /// <summary>
        /// Getter-Setter of Menus
        /// </summary>
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

            // SOUND
            _musicSound = new SoundPlayer(@"..\..\Sound\music.wav");
            //_musicSound.PlayLooping();

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
            string[] stringMenuNames3 = { "Resume", "Back to main menu" };
            Menus.Add(new Menu(stringMenuNames3, "Pause", _windowSize.X, _windowSize.Y));

            // Set the default menu onto the main menu
            _currentMenu = Menus[0];

            // Creation of the player
            _player = new Player(new Vector2D(35, 35));
            //_enemies.Add(new Enemy(new Vector2D(35, 10)));
        }

        /// <summary>
        /// Runs the game
        /// </summary>
        public void Run()
        {
            Console.Clear();
            _grpEnemies = new GroupEnemies(new Vector2D(2, 2), new Vector2D(5, 5), new Vector2D(1, 0), Direction.Right, 2);

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


                switch (_state)
                {
                    case GameManagerState.MainMenu:
                    case GameManagerState.Pause:
                    {
                        LoadMenu();
                        break;
                    }
                    case GameManagerState.MainGame:
                    {
                        MainGame();
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
                foreach (var enemy in _enemiesToDestroy)
                {
                    _enemies.Remove(enemy);
                }

                foreach (var bullet in _bulletsToDestroy)
                {
                    _bullets.Remove(bullet);
                }

                _enemiesToDestroy.Clear();
                _bulletsToDestroy.Clear();
                
                stopWatch.Stop();
                if (Convert.ToInt32(stopWatch.ElapsedMilliseconds) < DELTA_TIME)
                {
                    Thread.Sleep(DELTA_TIME - Convert.ToInt32(stopWatch.ElapsedMilliseconds));
                }

                tick++;
            }
        }

        /// <summary>
        /// Loop of the game
        /// </summary>
        private void MainGame()
        {
            /*
            foreach (var enemy in _enemies)
            {
                enemy.Update();
            }
            */
            _grpEnemies.Update(tick);

            foreach (var bullet in _bullets)
            {
                bullet.Update(tick);
            }

            _player.Update(tick);
        }

        /// <summary>
        /// Load the current menu
        /// </summary>
        private void LoadMenu()
        {
            // Draw the main menu with a full capital name
            _currentMenu.LoadPage(_currentMenu.Name.ToUpper());
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