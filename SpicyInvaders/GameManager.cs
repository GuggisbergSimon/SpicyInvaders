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
        private Menu _menu;
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
            Console.SetWindowSize(200, 60);

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
