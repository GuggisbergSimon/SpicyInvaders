//Authors       : HDN, KBY, YFA & SGG
//Date          : 24.04.2020
//Location      : ETML
//Description   : GameOver Class of Spicy Invaders

using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SpicyInvaders
{
    /// <summary>
    /// Gameover menu
    /// </summary>
    public class GameOver : Menu
    {
        private const string SCORE_TITLE = "YOUR SCORE";
        private const string NAME_TITLE = "TYPE YOUR NAME THEN PRESS ENTER";
        private const string NAME_CAUTION = "IT CANNOT BE EMPTY AND UPPER THAN 20 CHARACTERS";
        private readonly string[] NAME_RECTANGLE = { "╔═════════════════════════╗",
                                                     "║                         ║",
                                                     "╚═════════════════════════╝"};
        private List<char> _playerName;
        private int _score;

        public int Score
        {
            get { return _score; }
            set { _score = value; }
        }

        public GameOver(string[] buttonNames, string aName, int consoleWidth, int consoleHeight) : base(buttonNames, aName, consoleWidth, consoleHeight)
        {
            _playerName = new List<char>();
            _title = new string[] { " d888b   .d8b.  .88b  d88. d88888b    .d88b.  db    db d88888b d8888b.",
                                    "88' Y8b d8' `8b 88'YbdP`88 88'       .8P  Y8. 88    88 88'     88  `8D",
                                    "88      88ooo88 88  88  88 88ooooo   88    88 Y8    8P 88ooooo 88oobY'",
                                    "88  ooo 88~~~88 88  88  88 88~~~~~   88    88 `8b  d8' 88~~~~~ 88`8b",
                                    "88. ~8~ 88   88 88  88  88 88.       `8b  d8'  `8bd8'  88.     88 `88.",
                                    " Y888P  YP   YP YP  YP  YP Y88888P    `Y88P'     YP    Y88888P 88   YD" };
        }

        /// <summary>
        /// Draw the score and waiting the player to type his name
        /// </summary>
        public override void DrawOptions()
        {
            string score = Convert.ToString(_score);

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
            foreach(string line in NAME_RECTANGLE)
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
            Console.CursorLeft = Console.WindowWidth / 2 - NAME_RECTANGLE[0].Length / 2 + 2;
        }

        public override void KeyManager()
        {
            // Can write characters
            GameManager.Instance.Input = Console.ReadKey(false);
            // Loop for the selection of an option by pressing enter
            switch (GameManager.Instance.Input.Key)
            {
                case ConsoleKey.Enter:
                    {
                        if (_playerName.Count != 0) {
                            Console.CursorVisible = false;
                            HighscoreDB.WriteScore(new string(_playerName.ToArray()), _score);
                            _playerName.Clear();
                            _redraw = true;
                            // Clear because we change the menu page
                            Console.Clear();
                            GameManager.Instance.CurrentMenu = GameManager.Instance.Menus[0];
                            GameManager.Instance.State = GameManager.GameManagerState.MainMenu;
                        }
                        else
                        {
                            Console.CursorLeft = Console.WindowWidth / 2 - NAME_RECTANGLE[0].Length / 2 + 2;
                        }

                        break;
                    }
                case ConsoleKey.Backspace:
                    {
                        if (_playerName.Count != 0)
                        {
                            _playerName.RemoveAt(_playerName.Count - 1);
                            Console.Write(" \b");
                        }
                        else
                        {
                            // Stay here
                            Console.Write(" ");
                        }
                        
                        break;
                    }
                default:
                    {
                        if (_playerName.Count <= 22)
                        {
                            _playerName.Add(GameManager.Instance.Input.KeyChar);
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
