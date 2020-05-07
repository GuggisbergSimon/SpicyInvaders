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
		private static string xmlPath = @"..\..\Database\highscores.xml";

		/// <summary>
		/// Verify if the score can be written as the best score of the player, if yes, write it
		/// </summary>
		/// <param name="playerName">Player name</param>
		/// <param name="score">New score</param>
		public static void WriteScore(string playerName, int score)
		{
			XmlDocument doc = new XmlDocument();
			if (File.Exists(xmlPath))
			{
				doc.Load(xmlPath);

				foreach (XmlNode node in doc.DocumentElement)
				{
					// Select the right player
					if (node.Name == "player" && node.Attributes[0].InnerText == playerName)
					{
						// Set his score if it's less than the current score then leave to function to avoid to create a new player with the same name
						if (Int32.Parse(node.ChildNodes[0].InnerText) < score)
						{
							node.ChildNodes[0].InnerText = Convert.ToString(score);
							doc.Save(xmlPath);
							doc = null;
						}

						return;
					}
				}

				// If the player is not registered, create him in the DB
				AddNewPlayer(playerName, score);
			}
			else
			{
				// If the file doesn't exist
				CreateNewXML();
				// Recall the function
				WriteScore(playerName, score);
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
			doc.Load(xmlPath);

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
			doc.Save(xmlPath);

			// Delete the variables (avoid memory leak)
			playerElement = null;
			nameAttribute = null;
			scoreElement = null;
			doc = null;
		}

		/// <summary>
		/// Create the XML file
		/// </summary>
		/// <param name="playerName"></param>
		/// <param name="score"></param>
		private static void CreateNewXML()
		{
			XmlTextWriter writer = new XmlTextWriter(xmlPath, Encoding.UTF8);
			writer.WriteStartDocument(true);
			writer.Formatting = Formatting.Indented;
			writer.Indentation = 2;

			writer.WriteStartElement("players");
			writer.WriteEndElement();

			writer.WriteEndDocument();
			writer.Close();
		}

		/// <summary>
		/// Get a pair of the name and the best score of each player registered
		/// </summary>
		/// <returns></returns>
		public static Dictionary<string, int> GetScores()
		{
			Dictionary<string, int> scores = new Dictionary<string, int>();

			if (File.Exists(xmlPath))
			{
				XmlDocument doc = new XmlDocument();
				doc.Load(xmlPath);

				foreach (XmlNode node in doc.DocumentElement)
				{
					// Select each player node
					if (node.Name == "player")
					{
						string currentName = node.Attributes[0].InnerText;
						int currentScore = Int32.Parse(node.ChildNodes[0].InnerText);

						scores.Add(currentName, currentScore);
						doc = null;
					}
				}
			}
			else
			{
				CreateNewXML();
				GetScores();
			}

			return scores;
		}

		/// <summary>
		/// Return the five first highscore of the DB
		/// </summary>
		/// <returns></returns>
		public static string[,] SortFirstFive(Dictionary<string, int> scores)
		{
			string[,] highscores = new string[5, 2];

			int i = 0;
			foreach (KeyValuePair<string, int> keyValuePair in scores.OrderByDescending(key => key.Value))
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