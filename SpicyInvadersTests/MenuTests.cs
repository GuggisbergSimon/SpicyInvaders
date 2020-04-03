//Authors       : HDN, YFA, KBY & SGG
//Date          : 03.04.2020
//Location      : ETML
//Description   : Unit testing of the class Menu of Spicy Invaders

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpicyInvaders;
using System.Collections.Generic;

namespace SpicyInvadersTests
{
    [TestClass]
    public class MenuTests
    {
        [TestMethod]
        public void PrepareTextTest()
        {
            // Arrange
            string text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce fringilla quis nisl nec ornare. Vivamus posuere sapien quis justo aliquet, a pharetra ligula.";
            int numberOfCharaPerLine = 73;
            List<string> expectedResult = new List<string>
            {
                "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Fusce fringilla",
                "quis nisl nec ornare. Vivamus posuere sapien quis justo aliquet, a pharetra",
                "ligula."
            };
            string[] testButtonName = { "Test1", "Test2" };
            Menu testMenu = new Menu(testButtonName, "TestMenu", 200, 200);

            // Act
            var privateTestMethod = new PrivateObject(testMenu);
            var args = new object[2] { text, numberOfCharaPerLine };
            List<string> result = (List<string>)privateTestMethod.Invoke("PrepareText", args);

            // Assert
            CollectionAssert.AreEqual(expectedResult, result, "Error, the function PrepareText is broken.");
        }
    }
}
