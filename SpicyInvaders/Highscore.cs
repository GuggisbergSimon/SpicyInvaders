//Authors       : HDN, KBY, YFA & SGG
//Date          : 10.03.2020
//Location      : ETML
//Description   : Highscore Class of Spicy Invaders


using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SpicyInvaders
{
    /// <summary>
    /// Manager of the highscores
    /// </summary>
    public class Highscore
    {
        private Dictionary<string, int> _highscores;
        private string _path;
        private StreamWriter sw;

        public Dictionary<string, int> Highscores
        {
            get { return _highscores; }
            set { _highscores = value; }
        }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Highscore()
        {
            _highscores = new Dictionary<string, int>();

            // Create a path of the txt file in the streamwriter
            _path = Environment.CurrentDirectory + @"\highscore.txt";
            LoadPreviousHighscore();
        }

        /// <summary>
        /// Add a new score to the database
        /// </summary>
        /// <param name="usr">Username</param>
        /// <param name="score">Score</param>
        public void AddHighscore(string usr, int score)
        {
            if(_highscores.Count == 0)
            {
                _highscores.Add(usr, score);
            }

            foreach(KeyValuePair<string, int> keyPair in _highscores)
            {
                if (keyPair.Key == usr && score > keyPair.Value)
                {
                    _highscores.Remove(usr);
                    // add the highscore only if this is the user's best score
                    _highscores.Add(usr, score);
                    break;
                }
            }
            WriteScoresInFile();
        }

        /// <summary>
        /// Sort the highscores to obtain the 5 best ones by descending order
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, int> SortedHighscore()
        {
            Dictionary<string, int> sortedDic = new Dictionary<string, int>();
            int fiveFirst = 0;

            foreach (KeyValuePair<string, int> keyPair in _highscores.OrderByDescending(key => key.Value))
            {
                if (fiveFirst < 5)
                {
                    fiveFirst++;
                    sortedDic.Add(keyPair.Key, keyPair.Value);
                }
                else
                {
                    return sortedDic;
                }
            }

            // retourne un dictionnaire vide
            return sortedDic;
        }

        /// <summary>
        /// Delete the previous file and rewrite all the highscores
        /// </summary>
        private void WriteScoresInFile()
        {
            sw = new StreamWriter(_path, false);

            foreach (KeyValuePair<string, int> keyPair in _highscores)
            {
                sw.WriteLine(keyPair.Key + "|" + keyPair.Value);
            }

            sw.Close();
        }

        /// <summary>
        /// Load the highscores of the previous game
        /// </summary>
        private void LoadPreviousHighscore()
        {
            // Create an empty txt file
            sw = new StreamWriter(_path, false);
            sw.Close();

            string[] highscoreFile = File.ReadAllLines(_path);

            foreach (string highscore in highscoreFile)
            {
                string[] splitHighscore = highscore.Split('|');
                string name = splitHighscore[0];
                int point = Convert.ToInt32(splitHighscore[1]);
                _highscores.Add(name, point);
            }

            WriteScoresInFile();
        }
    }
}
