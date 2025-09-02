using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameBackend;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameBackend.Tests
{
    [TestClass()]
    public class CoordinateTests
    {
        [TestMethod()]
        public void CoordinateTest_ValidInputs()
        {
            // Arrange
            float expectedXCoordinate = 10;
            float expectedYCoordinate = 58;
            int ballWidth = 50;
            int ballHeight = 50;

            // Act
            Coordinate coordinate = new Coordinate(expectedXCoordinate, expectedYCoordinate, ballWidth, ballHeight);
            float actualXCoordinate = coordinate.X;
            float actualYCoordinate = coordinate.Y;

            // Assert
            Assert.AreEqual(expectedXCoordinate, actualXCoordinate);
            Assert.AreEqual(expectedYCoordinate, actualYCoordinate);
        }

        [TestMethod()]
        public void CoordinateTest_InvalidXCoordinate()
        {
            // Arrange
            float invalidXCoordinate = -10;
            float validYCoordinate = 58;
            int ballWidth = 50;
            int ballHeight = 50;

            // Act
            try
            {
                Coordinate coordinate = new Coordinate(invalidXCoordinate, validYCoordinate, ballWidth, ballHeight);
                // If error is not thrown, an error has occured
                // Assert
                Assert.Fail();
            } catch (ArgumentException e)
            {
            }
        }

        [TestMethod()]
        public void CoordinateTest_InvalidYCoordinate()
        {
            // Arrange
            float validXCoordinate = 10;
            float invalidYCoordinate = -58;
            int ballWidth = 50;
            int ballHeight = 50;

            // Act
            try
            {
                Coordinate coordinate = new Coordinate(validXCoordinate, invalidYCoordinate, ballWidth, ballHeight);
                // If error is not thrown, an error has occured
                // Assert
                Assert.Fail();
            }
            catch (ArgumentException e)
            {
            }
        }
    }
}