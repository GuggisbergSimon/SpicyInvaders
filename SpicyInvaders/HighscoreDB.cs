//Authors       : HDN, KBY, YFA & SGG
//Date          : 10.03.2020
//Location      : ETML
//Description   : Highscore Class of Spicy Invaders


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace SpicyInvaders
{
    /// <summary>
    /// Manager of the highscores
    /// </summary>
    public static class HighscoreDB
    {
        /// <summary>
        /// Verify if the score can be written as the best score of the player, if yes, write it
        /// </summary>
        /// <param name="playerName">Player name</param>
        /// <param name="score">New score</param>
        public static void WriteScore(string playerName, int score)
        {
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.Load("highscores.xml");

                foreach (XmlNode node in doc.DocumentElement)
                {
                    // Select the right player
                    if (node.Name == "player" && node.Attributes[0].InnerText == playerName)
                    {
                        // Set his score if it's less than the current score then leave to function to avoid to create a new player with the same name
                        if (Int32.Parse(node.ChildNodes[0].InnerText) < score)
                        {
                            node.ChildNodes[0].InnerText = Convert.ToString(score);
                            doc.Save("highscores.xml");
                        }
                        return;
                    }
                }

                // If the player is not registered, create him in the DB
                AddNewPlayer(playerName, score);
            }
            catch
            {
                // If the file doesn't exist
                CreateNewXML(playerName, score);
            }
        }

        /// <summary>
        /// If it's the first game of the player, add it to the DB
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="score"></param>
        private static void AddNewPlayer(string playerName, int score)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("highscores.xml");

            // Create the player node
            XmlNode playerElement = doc.CreateElement("player");

            // Add the attribute Name in the player node
            XmlAttribute nameAttribute = doc.CreateAttribute("name");
            nameAttribute.InnerText = playerName;
            playerElement.Attributes.Append(nameAttribute);

            // Add the score element to the player node
            XmlNode scoreElement = doc.CreateElement("score");
            scoreElement.InnerText = Convert.ToString(score);
            playerElement.AppendChild(scoreElement);

            doc.DocumentElement.AppendChild(playerElement);
            doc.Save("highscores.xml");
        }

        /// <summary>
        /// Create the XML file
        /// </summary>
        /// <param name="playerName"></param>
        /// <param name="score"></param>
        private static void CreateNewXML(string playerName, int score)
        {
            XmlTextWriter writer = new XmlTextWriter("highscores.xml", Encoding.UTF8);
            writer.WriteStartDocument(true);
            writer.Formatting = Formatting.Indented;
            writer.Indentation = 2;

            writer.WriteStartElement("players");
            writer.WriteEndElement();

            writer.WriteEndDocument();
            writer.Close();

            // Try again after creating the file
            WriteScore(playerName, score);
        }

        /// <summary>
        /// Return the five first highscore of the DB
        /// </summary>
        /// <returns></returns>
        public static string[,] SortFirstFive()
        {
            string[,] highscores = new string[5, 2];
            Dictionary<string, int> scores = new Dictionary<string, int>();

            XmlDocument doc = new XmlDocument();
            doc.Load("highscores.xml");

            foreach (XmlNode node in doc.DocumentElement)
            {
                // Select each player node
                if (node.Name == "player")
                {
                    string currentName = node.Attributes[0].InnerText;
                    int currentScore = Int32.Parse(node.ChildNodes[0].InnerText);

                    scores.Add(currentName, currentScore);
                }
            }

            int i = 0;
            foreach(KeyValuePair<string, int> keyValuePair in scores.OrderByDescending(key => key.Value))
            {
                if (i >= 5)
                {
                    break;
                }
                else
                {
                    highscores[i, 0] = keyValuePair.Key;
                    highscores[i, 1] = Convert.ToString(keyValuePair.Value);
                }
                i++;
            }

            return highscores;
        }
    }
}
