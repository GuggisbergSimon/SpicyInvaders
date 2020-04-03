using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpicyInvaders;

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
            string[,] realHighscores = { { "Hugo", "20"}, { "Julien", "15" }, { "Simon", "10"}, { "Ylli", "5"}, {"Bob", "1"}};

            // Act


            // Assert
            Assert.IsNotNull(HighscoreDB.SortFirstFive());

        }
    }
}
