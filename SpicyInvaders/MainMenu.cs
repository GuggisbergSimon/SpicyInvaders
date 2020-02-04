//Authors       : HDN, YFA, KBY & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : Menu Class of Spicy Invaders

using System;
using System.Collections.Generic;
using System.Diagnostics;

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

    /// <summary>
    /// Main menu class. Manage the menu selection and interactions
    /// </summary>
    public class Menu
    {
        // List of all the menus available in Spicy Invaders
        public static List<Menu> listMenus = new List<Menu>();

        // Title of the game on the screen (generate with https://www.kammerl.de/ascii/AsciiSignature.php)
        private const string _TITLE = @".d8888. d8888b. d888888b  .o88b. db    db   d888888b d8b   db db    db  .d8b.  d8888b. d88888b d8888b. .d8888.
                                        88'  YP 88  `8D   `88'   d8P  Y8 `8b  d8'     `88'   888o  88 88    88 d8' `8b 88  `8D 88'     88  `8D 88'  YP
                                        `8bo.   88oodD'    88    8P       `8bd8'       88    88V8o 88 Y8    8P 88ooo88 88   88 88ooooo 88oobY' `8bo.
                                          `Y8b. 88~~~      88    8b         88         88    88 V8o88 `8b  d8' 88~~~88 88   88 88~~~~~ 88`8b     `Y8b.
                                        db   8D 88        .88.   Y8b  d8    88        .88.   88  V888  `8bd8'  88   88 88  .8D 88.     88 `88. db   8D
                                        `8888Y' 88      Y888888P  `Y88P'    YP      Y888888P VP   V8P    YP    YP   YP Y8888D' Y88888P 88   YD `8888Y'";

        private readonly List<string> _menuNames = new List<string>();
        private const int _WINDOW_X = 200;
        private const int _WINDOW_Y = 60;

        // Array containing each menu options as objects of the class MenuButton
        private readonly List<MenuButton> _menuButtons = new List<MenuButton>();
        // Index of the selected button on the menu (0 to 4)
        private int _selectedIndex = 0;

        // Property of the selected index
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }

        /// <summary>
        /// Custom constructor
        /// </summary>
        public Menu(string[] buttonNames)
        {
            int i = 0;

            foreach (string name in buttonNames)
            {
                i++;
                _menuNames.Add(name);

                // Creation of the menu options throughout the custom constructor of the MenuButton class
                MenuButton newBtn = new MenuButton
                {
                    X = 2 * _WINDOW_X / 3,
                    Y = _WINDOW_Y / 4 + (5 * i),
                    Name = name.ToUpper()
                };

                _menuButtons.Add(newBtn);
            }
        }

        /// <summary>
        /// Basic draw of each button with the Play button selected
        /// </summary>
        public void DrawOptions()
        {
            // Draw each option button
            for (int j = 0; j < _menuButtons.Count; j++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;

                // If the option is selected, draw an arrow in front of it
                if (j == SelectedIndex)
                {
                    // Write the arrow in front of the button
                    Console.SetCursorPosition(_menuButtons[j].X - 3, _menuButtons[j].Y);
                    Console.Write((char)62);

                    // Draw the menu option with selected design
                    Console.SetCursorPosition(_menuButtons[j].X, _menuButtons[j].Y);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(_menuButtons[j].Name);
                }
                else
                {
                    // Draw the menu option with normal design
                    Console.SetCursorPosition(_menuButtons[j].X, _menuButtons[j].Y);
                    Console.Write(_menuButtons[j].Name);
                }
            }

            // reset the color of the cursor
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Redraw the menu buttons after moving the cursor
        /// </summary>
        public void MoveCursor(ArrowDirection direction)
        {
            // Remove old arrow
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
            else
            {
                SelectedIndex = (SelectedIndex + 1) % _menuButtons.Count;
            }

            // Redraw each option button
            for (int j = 0; j < _menuButtons.Count; j++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;

                // If the option is selected, draw an arrow in front of it
                if (j == SelectedIndex)
                {
                    // Write the arrow in front of the button
                    Console.SetCursorPosition(_menuButtons[j].X - 3, _menuButtons[j].Y);
                    Console.Write((char)62);

                    // Draw the menu option with selected design
                    Console.SetCursorPosition(_menuButtons[j].X, _menuButtons[j].Y);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(_menuButtons[j].Name);
                }
                else
                {
                    // Draw the menu option with normal design
                    Console.SetCursorPosition(_menuButtons[j].X, _menuButtons[j].Y);
                    Console.Write(_menuButtons[j].Name);
                }
            }

            // reset the color of the cursor
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }

        /// <summary>
        /// Draw the 'Spicy Invaders' title
        /// </summary>
        public void DrawTitle()
        {
            // Draw title
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(_WINDOW_X / 2 - _TITLE.Length / 12 + 12, 5);
            Console.Write(_TITLE + "\n\n");

            // Write a line under the title
            for (int i = 0; i < _WINDOW_X; i++)
            {
                Console.Write("_");
            }
        }

        /// <summary>
        /// Draw the title and a page subtitle (overload of the function DrawTitle)
        /// </summary>
        /// <param name="pageTitle">Displayed string</param>
        public void DrawTitle(string pageTitle)
        {
            // Draw the spicy invaders title
            DrawTitle();
            // Draw the subtitle of the page
            Console.Write("\n");
            Console.CursorLeft = _WINDOW_X / 2 - pageTitle.Length / 2;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(pageTitle);
            Console.Write("\n\n");
        }

        /// <summary>
        /// Draw the settings page
        /// </summary>
        public void DrawPage(string title)
        {
            Console.Clear();
            SelectedIndex = 0;
            DrawTitle(title);
            DrawOptions();
            KeyManager();
        }

        /// <summary>
        /// Manage which key
        /// </summary>
        public void KeyManager()
        {
            bool selectOption = false;

            // Loop for the selection of an option by pressing enter
            while (!selectOption)
            {
                ConsoleKeyInfo key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.DownArrow:
                        // false = move down
                        MoveCursor(ArrowDirection.Down);
                        break;
                    case ConsoleKey.UpArrow:
                        // true = move up
                        MoveCursor(ArrowDirection.Up);
                        break;
                    case ConsoleKey.Escape:
                        Console.Clear();
                        Menu.listMenus[0].DrawTitle();
                        Menu.listMenus[0].DrawOptions();
                        Menu.listMenus[0].KeyManager();
                        break;
                    case ConsoleKey.Enter:
                        // leave the loop
                        selectOption = true;

                        // Which button is selected
                        for (int i = 0; i < _menuButtons.Count; i++)
                        {
                            // The last button is always the quit button
                            if (_menuButtons[i].Name == "QUIT")
                            {
                                Environment.Exit(0);
                            }
                            else if (_menuButtons[i].Name == "BACK")
                            {
                                Console.Clear();
                                Menu.listMenus[0].DrawTitle();
                                Menu.listMenus[0].DrawOptions();
                                Menu.listMenus[0].KeyManager();
                                break;
                            }

                            // Draw the page button in function of the selected button
                            if (SelectedIndex == i)
                            {
                                string[] stringName = { "Sound", "Mute", "Back" };
                                Menu.listMenus.Add(new Menu(stringName));
                                Menu.listMenus[1].DrawPage(_menuButtons[i].Name.ToUpper());
                            }
                        }

                        break;
                    default:
                        break;
                }
            }
        }

    }
}
