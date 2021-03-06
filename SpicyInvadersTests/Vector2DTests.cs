﻿//Authors       : HDN, KBY, YFA & SGG
//Date          : 10.03.2020
//Location      : ETML
//Description   : Highscore Class of Spicy Invaders

using Microsoft.VisualStudio.TestTools.UnitTesting;
using SpicyInvaders;

namespace SpicyInvadersTests
{
    /// <summary>
    /// Vector2D Tests class
    /// </summary>
    [TestClass]
    public class Vector2DTests
    {
        /// <summary>
        /// Addition test
        /// </summary>
        [TestMethod]
        public void AdditionOperatorTest()
        {
            // Arrange
            Vector2D vector1;
            Vector2D vector2;
            Vector2D expectedVector;

            // Act
            vector1 = new Vector2D(1, 2);
            vector2 = new Vector2D(3, 4);
            expectedVector = new Vector2D(4, 6);

            // Assert
            Assert.AreEqual(expectedVector, vector1 + vector2, "Error, the addition operation doesn't work anymore.");
        }

        /// <summary>
        /// Substraction test
        /// </summary>
        [TestMethod]
        public void SubstractOperatorTest()
        {
            // Arrange
            Vector2D vector1;
            Vector2D vector2;
            Vector2D expectedVector;

            // Act
            vector1 = new Vector2D(1, 2);
            vector2 = new Vector2D(3, 4);
            expectedVector = new Vector2D(-2, -2);

            // Assert
            Assert.AreEqual(expectedVector, vector1 - vector2, "Error, the substract operation doesn't work anymore.");
        }

        /// <summary>
        /// Inversion test
        /// </summary>
        [TestMethod]
        public void InversionOperatorTest()
        {
            // Arrange
            Vector2D vector;
            Vector2D expectedVector;

            // Act
            vector = new Vector2D(1, -2);
            expectedVector = new Vector2D(-1, 2);

            // Assert
            Assert.AreEqual(expectedVector, -vector, "Error, the inversion doesn't work anymore.");
        }

        /// <summary>
        /// Multiplication test
        /// </summary>
        [TestMethod]
        public void MultiplicationOperatorTest()
        {
            // Arrange
            int k;
            Vector2D vector;
            Vector2D expectedVector;

            // Act
            vector = new Vector2D(1, 2);
            k = 6;
            expectedVector = new Vector2D(6, 12);

            // Assert
            Assert.AreEqual(expectedVector, vector * k, "Error, the multiplication doesn't work anymore.");
        }

        /// <summary>
        /// Division test
        /// </summary>
        [TestMethod]
        public void DivisionOperatorTest()
        {
            // Arrange
            Vector2D vector;
            int k;
            Vector2D expectedVector;

            // Act
            vector = new Vector2D(4, 2);
            k = 2;
            expectedVector = new Vector2D(2, 1);

            // Assert
            Assert.AreEqual(expectedVector, vector / k, "Error, the divison doesn't work anymore.");
        }

        /// <summary>
        /// Equals operator test
        /// </summary>
        [TestMethod]
        public void EqualsOperatorTest()
        {
            // Arrange
            Vector2D vector1;
            Vector2D vector2;

            // Act
            vector1 = new Vector2D(1, 2);
            vector2 = new Vector2D(1, 2);

            // Assert
            Assert.IsTrue(vector1 == vector2, "Error, the equal operation doesn't work anymore.");
        }

        /// <summary>
        /// Not Equals test
        /// </summary>
        [TestMethod]
        public void NotEqualOperatorTest()
        {
            // Arrange
            Vector2D vector1;
            Vector2D vector2;

            // Act
            vector1 = new Vector2D(1, 2);
            vector2 = new Vector2D(1, 4);

            // Assert
            Assert.IsTrue(vector1 != vector2, "Error, the not equal operation doesn't work anymore.");
        }

        /// <summary>
        /// Equals method test
        /// </summary>
        [TestMethod]
        public void EqualsMethodTest()
        {
            // Arrange
            Vector2D vector1;
            Vector2D vector2;

            // Act
            vector1 = new Vector2D(1, 2);
            vector2 = new Vector2D(3, 4);

            // Assert
            Assert.IsFalse(vector1.Equals(vector2), "Error, the equals method doesn't work anymore.");
        }
    }
}
