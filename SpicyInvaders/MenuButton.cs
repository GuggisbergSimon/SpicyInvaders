//Authors       : HDN, YFA, KBY & SGG
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
        /// <summary>
        /// Getter-Setter of Name of the option
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Getter-Setter of the Position of the option
        /// </summary>
        public Vector2D Position { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public MenuButton(Vector2D position, string name)
        {
            Position = position;
            Name = name;
        }
    }
}
