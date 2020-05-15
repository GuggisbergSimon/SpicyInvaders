//Authors       : HDN, KBY, YFA & SGG
//Date          : 10.03.2020
//Location      : ETML
//Description   : Highscore Class of Spicy Invaders

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpicyInvaders;
using System.Collections.Generic;

namespace SpicyInvadersTests
{
    [TestClass]
    public class HighscoreDBTests
    {
        [TestMethod]
        public void SortFiveTest()
        {
            // Arrange
            string[,] highscores = new string[5, 2];
            Dictionary<string, int> scores = new Dictionary<string, int>();
            string[,] expectedResult = { { "Hugo", "20"}, { "Julien", "15" }, { "Simon", "10"}, { "Ylli", "5"}, {"Bob", "1"}};
            string[,] result;

            // Act
            scores.Add("Hugo", 20);
            scores.Add("Julien", 15);
            scores.Add("Ylli", 5);
            scores.Add("Bob", 1);
            scores.Add("Simon", 10);
            result = HighscoreDB.SortFirstFive(scores);

            // Assert
            CollectionAssert.AreEqual(expectedResult, result, "Error, the function SortFive is broken.");
        }
    }
}
