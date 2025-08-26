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
    public class BallTests
    {
        [TestMethod()]
        public void BallTest_ValidInputs()
        {
            // Arrange
            float expectedXCoordinate = 55;
            float expectedYCoordinate = 12;

            // Act
            Ball ball = new Ball(expectedXCoordinate, expectedYCoordinate);
            float actualXCoordinate = ball.Coordinate.X;
            float actualYCoordinate = ball.Coordinate.Y;

            //Assert
            Assert.AreEqual(expectedXCoordinate, actualXCoordinate);
            Assert.AreEqual(expectedYCoordinate, actualYCoordinate);
        }

        [TestMethod()]
        public void BallTest_InvalidInputs()
        {
            // Arrange
            float invalidXCoordinate = -55;
            float validYCoordinate = 12;

            // Act
            try
            {
                Ball ball = new Ball(invalidXCoordinate, validYCoordinate);

                // Assert
                Assert.Fail();
            }
            catch (ArgumentException e) 
            {
            }
        }

        [TestMethod()]
        public void MoveTest()
        {
            // Arrange
            float xCoordinate = 50;
            float yCoordinate = 50;
            Ball ball = new Ball(xCoordinate, yCoordinate);

            float expectedXCoordinate = xCoordinate + 1;
            float expectedYCoordinate = yCoordinate + 1;

            // Act
            ball.Move();
            float actualXCoordinate = ball.Coordinate.X;
            float actualYCoordinate = ball.Coordinate.Y;

            //Assert
            Assert.AreEqual(expectedXCoordinate, actualXCoordinate);
            Assert.AreEqual(expectedYCoordinate, actualYCoordinate);
        }
    }
}