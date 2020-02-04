﻿//Authors       : HDN, YFA, KBY & SGG
//Date          : 17.01.2020
//Location      : ETML
//Description   : MenuButton Class of Spicy Invaders

namespace SpicyInvaders
{
    /// <summary>
    /// Each button of the main menu
    /// </summary>
    public class MenuButton
    {
        // X position of the button
        private int _x;
        // Y position of the button
        private int _y;
        // Name of the menu button
        private string _name;

        // Property of the name's option
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Property of the x position
        public int X
        {
            get { return _x; }
            set { _x = value; }
        }

        // Property of the y position
        public int Y
        {
            get { return _y; }
            set { _y = value; }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MenuButton()
        {

        }

        /// <summary>
        /// Custom constructor
        /// </summary>
        /// <param name="x">X position</param>
        /// <param name="y">Y position</param>
        /// <param name="name">Name of the setting</param>
        public MenuButton(int x, int y, string name)
        {
            _x = x;
            _y = y;
            _name = name;
        }

    }
}
