// Auteur : HDN
// Date   : 24.01.2020
// Lieu   : ETML
// Description : Classe du menu principal


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicyInvaders
{
    // Main menu class. Manage the menu selection and interactions
    public class MainMenu
    {
        // Title of the game on the screen
        private const string _TITLE = "SPICY INVADERS";
        private readonly string[] menuNames = new string[] { "Play", "Settings", "Highscore", "About", "Quit"};
        private const int _WINDOW_X = 100;
        private const int _WINDOW_Y = 50;

        // Array containing each menu options as objects of the class
        MenuButton[] menuButtons = new MenuButton[5];
        // Index of the selected button on the menu
        private int _selectedIndex = 1;

        // Property of the selected index
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set { _selectedIndex = value; }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MainMenu()
        {
            // Creation of the 5 menu option throughout the custom constructor
            for (int i = 0; i < 5; i++)
            {
                menuButtons[i] = new MenuButton
                {
                    X = 2 * _WINDOW_X / 3,
                    Y = _WINDOW_Y / 4 + (5 * i),
                    Name = menuNames[i].ToUpper()
                };
            }
        }

        /// <summary>
        /// Refresh the menu each tick
        /// </summary>
        public void Refresh(bool isUp)
        {
            // Remove old arrow
            Console.SetCursorPosition(menuButtons[SelectedIndex].X - 2, menuButtons[SelectedIndex].Y);
            Console.Write("\b \b");

            // If the key pressed is the up arrow button
            if (isUp)
            {
                // to avoid negative numbers
                if (SelectedIndex == 0)
                {
                    SelectedIndex = 4;
                }
                else
                {
                    SelectedIndex = (SelectedIndex - 1) % 5;
                }
            }
            else
            {
                SelectedIndex = (SelectedIndex + 1) % 5;
            }

            // Draw title
            Console.SetCursorPosition(_WINDOW_X / 2 - _TITLE.Length / 2, 5);
            Console.Write(_TITLE);


            // Draw each option
            for (int j = 0; j < menuButtons.Length; j++)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.BackgroundColor = ConsoleColor.Black;

                // If the option is selected, draw an arrow in front of it
                if (j == SelectedIndex)
                {
                    // Write the arrow in front of the button
                    Console.SetCursorPosition(menuButtons[j].X - 3, menuButtons[j].Y);
                    Console.Write((char)62);

                    // Draw the menu option with selected design
                    Console.SetCursorPosition(menuButtons[j].X, menuButtons[j].Y);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.Write(menuButtons[j].Name);
                }
                else
                {
                    // Draw the menu option with normal design
                    Console.SetCursorPosition(menuButtons[j].X, menuButtons[j].Y);
                    Console.Write(menuButtons[j].Name);
                }
            }

            // reset the color of the cursor
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.White;
        }


    }
}
