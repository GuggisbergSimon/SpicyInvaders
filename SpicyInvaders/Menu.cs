//Authors       : HDN, YFA, KBY & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Menu Class of Spicy Invaders

using System;
using System.Collections.Generic;

namespace SpicyInvaders
{
    /// <summary>
    /// Enum to know what is the direction of the arrow pressed in the menu
    /// </summary>
    public enum ArrowDirection
    {
        Up,
        Down
    }

    public enum MuteState
    {
        Enabled,
        Disabled
    }

    /// <summary>
    /// Main menu class. Manage the menu selection and interactions
    /// </summary>
    public class Menu
    {
        /// <summary>
        /// ATTRIBUTES
        /// </summary>
        public static MuteState _muteState;

        // Title of the game on the screen (generated with https://www.kammerl.de/ascii/AsciiSignature.php)
        protected string[] _title = {".d8888. d8888b. d888888b  .o88b. db    db   d888888b d8b   db db    db  .d8b.  d8888b. d88888b d8888b. .d8888.",
                                     "88'  YP 88  `8D   `88'   d8P  Y8 `8b  d8'     `88'   888o  88 88    88 d8' `8b 88  `8D 88'     88  `8D 88'  YP",
                                     "`8bo.   88oodD'    88    8P       `8bd8'       88    88V8o 88 Y8    8P 88ooo88 88   88 88ooooo 88oobY' `8bo.",
                                     "  `Y8b. 88~~~      88    8b         88         88    88 V8o88 `8b  d8' 88~~~88 88   88 88~~~~~ 88`8b     `Y8b.",
                                     "db   8D 88        .88.   Y8b  d8    88        .88.   88  V888  `8bd8'  88   88 88  .8D 88.     88 `88. db   8D",
                                     "`8888Y' 88      Y888888P  `Y88P'    YP      Y888888P VP   V8P    YP    YP   YP Y8888D' Y88888P 88   YD `8888Y'" };

        private const string _ABOUT_TITLE_1 = "Spicy Invaders";
        private const string _ABOUT_1 = "The project Spicy Invaders is a true copy of the famous game Space Invaders. The goal wasn't to steal the concept, " +
                                        "because we're not gonna sell this game, but rather to create an entire oriented object game by ourself.";

        private const string _ABOUT_TITLE_2 = "About us";
        private const string _ABOUT_2 = "We are a team of four young developers. Simon Guggisberg, Ylli Fazlija, Hugo Ducommun and Karim Boraley. This project " +
                                        "has been produced during our education in computer science. The goal was to know how to work in groups with different " +
                                        "levels of coding. It grows our teamwork sense! We are pretty proud of our game even if it’s not perfect but we hope " +
                                        "you enjoy the game :)";

        // Array containing each menu buttons as objects of the class MenuButton
        private readonly List<MenuButton> _menuButtons = new List<MenuButton>();
        // Index of the selected button on the menu (0 to (_menuButtons.Length - 1))
        private int _selectedIndex = 0;
        // Name of the menu
        private readonly string _name;
        // If true, the program refresh the page automatically
        protected bool _redraw = true;
        /// <summary>
        /// END ATTRIBUTES
        /// </summary>

        /// <summary>
        /// Getter-Setter of SelectedIndex
        /// </summary>
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }

        /// <summary>
        /// Getter of MenuButtons
        /// </summary>
        public List<MenuButton> MenuButtons
        {
            get { return _menuButtons; }
        }

        /// <summary>
        /// Getter of Name
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// END PROPERTIES
        /// </summary>

        /// <summary>
        /// Custom constructor
        /// </summary>
        public Menu(string[] buttonNames, string aName, int consoleWidth, int consoleHeight)
        {
            _name = aName;

            int i = 0;
            foreach (string name in buttonNames)
            {
                i++;

                // Creation of the menu options throughout the custom constructor of the MenuButton class
                MenuButton newBtn = new MenuButton
                {
                    X = 2 * consoleWidth / 3,
                    Y = consoleHeight / 4 + (5 * i),
                    Name = name.ToUpper()
                };

                _menuButtons.Add(newBtn);
            }
        }

        /// <summary>
        /// Basic draw of each button with the Play button selected
        /// </summary>
        public virtual void DrawOptions()
        {
            // Draw some text if it's about page
            if (this == GameManager.Instance.Menus[3])
            {
                DrawText(_ABOUT_TITLE_1, _ABOUT_1);
                DrawText(_ABOUT_TITLE_2, _ABOUT_2);
            }
            // Draw some text if it's highscore page
            else if (this == GameManager.Instance.Menus[2])
            {
                // Catch the first 5 best scores (name and score)
                string[,] firstFive = HighscoreDB.SortFirstFive(HighscoreDB.GetScores());

                for (int i = 0; i < firstFive.GetLength(0); i++)
                {
                    // If it's not empty
                    if (firstFive[i, 0] != "")
                    {
                        string name = firstFive[i, 0];
                        string score = firstFive[i, 1];
                        DrawText((i + 1) + ". " + name, "   " + score);
                    }
                }
            }

            DrawButtons();
        }

        /// <summary>
        /// Draw every buttons of the page
        /// </summary>
        private void DrawButtons()
        {
            // Draw each option button
            for (int j = 0; j < _menuButtons.Count; j++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;

                // If it's the mute button (keep his state)
                if (_menuButtons[j].Name == "MUTE :          DISABLED" || _menuButtons[j].Name == "MUTE :          ENABLED")
                {
                    _menuButtons[j].Name = "MUTE :          " + _muteState.ToString().ToUpper();
                }

                // If the option is selected
                if (j == SelectedIndex)
                {
                    // Write the arrow in front of the button
                    Console.SetCursorPosition(_menuButtons[j].X - 3, _menuButtons[j].Y);
                    Console.Write((char)62);

                    // Draw the menu button with selected design
                    Console.SetCursorPosition(_menuButtons[j].X, _menuButtons[j].Y);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(_menuButtons[j].Name);
                }
                else
                {
                    // Draw the menu button with normal design
                    Console.SetCursorPosition(_menuButtons[j].X, _menuButtons[j].Y);
                    Console.Write(_menuButtons[j].Name);
                }
            }

            // reset the color of the cursor
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Cut the text into different lines that can be displayed on the left of the menu
        /// </summary>
        /// <returns>A list of each line</returns>
        private List<string> PrepareText(string text, int numberOfCharaPerLine)
        {
            List<string> result = new List<string>();
            int charaCounter = 0;
            int textCounter = 0;
            string line = "";

            // If it's a small text, return it without change
            if (text.Length <= numberOfCharaPerLine)
            {
                result.Add(text);
            }
            // Else cut it into lines
            else
            {
                foreach (char chara in text)
                {
                    charaCounter++;
                    textCounter++;

                    // If it's a space and it's at the end of the paragraph
                    if (chara == (char)32 && charaCounter >= numberOfCharaPerLine)
                    {
                        result.Add(line);
                        charaCounter = 0;
                        line = "";
                    }
                    else
                    {
                        line += chara;
                    }

                    // If this is the last character
                    if (textCounter == text.Length)
                    {
                        result.Add(line);
                        break;
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Draw a title and a paragraph on the left of the window
        /// </summary>
        private void DrawText(string title, string paragraph)
        {
            // Where the paragraphe must start
            int startParagraph = Console.WindowWidth / 5;
            // Where the paragraphe must end
            int endParagraph = _menuButtons[0].X - 20;

            // Draw a white title
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft = startParagraph;
            Console.CursorTop += 3; // Too close of the menu title
            Console.Write(title + "\n\n");

            // Draw the green paragraph
            Console.ForegroundColor = ConsoleColor.Green;
            int lineLength = endParagraph - startParagraph;

            foreach (string line in PrepareText(paragraph, lineLength))
            {
                // Reset the cursor position
                Console.CursorLeft = startParagraph;
                // test at each space if it's at the end of the paragraph
                Console.WriteLine(line);
            }
        }

        /// <summary>
        /// Redraw the menu buttons after moving the cursor
        /// </summary>
        private void MoveCursor(ArrowDirection direction)
        {
            // Remove old arrow by "hand"
            Console.SetCursorPosition(_menuButtons[SelectedIndex].X - 2, _menuButtons[SelectedIndex].Y);
            Console.Write("\b \b");

            // If the key pressed is the up arrow button
            if (direction == ArrowDirection.Up)
            {
                // Avoid negative numbers
                if (SelectedIndex == 0)
                {
                    SelectedIndex = _menuButtons.Count - 1;
                }
                else
                {
                    SelectedIndex = (SelectedIndex - 1) % _menuButtons.Count;
                }
            }
            // If the key pressed is the down arrow button
            else
            {
                SelectedIndex = (SelectedIndex + 1) % _menuButtons.Count;
            }

            DrawButtons();
        }

        /// <summary>
        /// Draw the 'Spicy Invaders' title
        /// </summary>
        /// <param name="pageTitle">A page subtitle</param>
        public void DrawBigTitle(string pageTitle)
        {
            // Draw title
            Console.ForegroundColor = ConsoleColor.White;
            int j = 0;
            foreach(string line in _title)
            {
                j++;
                Console.SetCursorPosition(Console.WindowWidth / 2 - _title[0].Length / 2, 2 + j);
                Console.Write(line);
            }
            Console.Write("\n\n\n");

            // Write a line of underscore under the title
            for (int i = 0; i < Console.WindowWidth; i++)
            {
                Console.Write("_");
            }

            // Draw a subtitle of the page (if there is one)
            Console.Write("\n");
            Console.CursorLeft = Console.WindowWidth / 2 - pageTitle.Length / 2;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(pageTitle);
            Console.Write("\n\n");
        }


        /// <summary>
        /// Draw a full page
        /// </summary>
        /// <param name="title">Page's title</param>
        public void LoadPage(string title)
        {
            if (_redraw)
            {
                DrawBigTitle(title);
                DrawOptions();
                _redraw = false;
            }
            KeyManager();
        }

        /// <summary>
        /// Manage which key is pressed and what action it activates
        /// </summary>
        public virtual void KeyManager()
        {
            // Loop for the selection of an option by pressing enter
            switch (GameManager.Instance.Input.Key)
            {
                case ConsoleKey.DownArrow:
                    {
                        MoveCursor(ArrowDirection.Down);
                        _redraw = true;
                        break;
                    }
                case ConsoleKey.UpArrow:
                    {
                        MoveCursor(ArrowDirection.Up);
                        _redraw = true;
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        // Clear because we change the menu page
                        Console.Clear();
                        // Get back to the main menu
                        GameManager.Instance.CurrentMenu = GameManager.Instance.Menus[0];
                        _redraw = true;
                        break;
                    }
                case ConsoleKey.Enter:
                    {
                        // Clear because we change the menu page
                        Console.Clear();

                        // Which button is selected
                        for (int i = 0; i < _menuButtons.Count; i++)
                        {
                            // If the button is the selected one
                            if (SelectedIndex == i)
                            {
                                switch (_menuButtons[i].Name)
                                {
                                    case "QUIT":
                                        {
                                            Environment.Exit(0);
                                            break;
                                        }
                                    case "PLAY":
                                    case "RESUME":
                                        {
                                            // Run the game
                                            if (_menuButtons[i].Name.Equals("PLAY")) { GameManager.Instance.Score = 0; }
                                            // todo resize window
                                            GameManager.Instance.State = GameManager.GameManagerState.MainGame;
                                            break;
                                        }
                                    case "BACK":
                                    case "BACK TO MAIN MENU":
                                        {
                                            // Get back to the main menu
                                            GameManager.Instance.CurrentMenu = GameManager.Instance.Menus[0];
                                            break;
                                        }
                                    case "SETTINGS":
                                        {
                                            // Go to the settings menu
                                            GameManager.Instance.CurrentMenu = GameManager.Instance.Menus[1];
                                            break;
                                        }
                                    case "HIGHSCORE":
                                        {
                                            // Go to the highscore menu
                                            GameManager.Instance.CurrentMenu = GameManager.Instance.Menus[2];
                                            break;
                                        }
                                    case "ABOUT":
                                        {
                                            // Go to the about menu
                                            GameManager.Instance.CurrentMenu = GameManager.Instance.Menus[5];
                                            break;
                                        }
                                    case "MUTE :          DISABLED":
                                    case "MUTE :          ENABLED":
                                        {
                                            if (_muteState == MuteState.Disabled)
                                            {
                                                // Stop the sound
                                                _muteState = MuteState.Enabled;
                                                GameManager.Instance.MusicSound.Stop();
                                                _menuButtons[i].Name = "MUTE :          ENABLED";
                                            }
                                            else
                                            {
                                                // Activate the sound
                                                _muteState = MuteState.Disabled;
                                                GameManager.Instance.MusicSound.PlayLooping();
                                                _menuButtons[i].Name = "MUTE :          DISABLED";
                                            }
                                            break;
                                        }
                                    case "DIFFICULTY :    EASY":
                                        {
                                            // Set the difficulty to hard
                                            GameManager.Instance.Difficulty = GameManager.GameDifficulty.Hard;
                                            _menuButtons[i].Name = "DIFFICULTY :    HARD";
                                            break;
                                        }
                                    case "DIFFICULTY :    HARD":
                                        {
                                            // Set the difficulty to easy
                                            GameManager.Instance.Difficulty = GameManager.GameDifficulty.Easy;
                                            _menuButtons[i].Name = "DIFFICULTY :    EASY";
                                            break;
                                        }
                                    default:
                                        {
                                            break;
                                        }
                                }
                            }
                        }
                        _redraw = true;
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}