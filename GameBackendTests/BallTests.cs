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
			int expectedWidth = 50;
			int expectedHeight = 50;
			int screenWidth = 800;
			int screenHeight = 600;

			// Act
			Ball ball = new Ball(expectedXCoordinate, expectedYCoordinate, expectedWidth, expectedHeight, screenWidth, screenHeight);
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

			int expectedWidth = 50;
			int expectedHeight = 50;
			int screenWidth = 800;
			int screenHeight = 600;

			// Act
			try
			{
				Ball ball = new Ball(invalidXCoordinate, validYCoordinate, expectedWidth, expectedHeight, screenWidth, screenHeight);

				// Assert
				Assert.Fail();
			}
			catch (ArgumentException)
			{
			}
		}

		[TestMethod()]
		public void MoveTest()
		{
			// Arrange
			float xCoordinate = 50;
			float yCoordinate = 50;
			int vx = 2;
			int vy = 2;

			int width = 50;
			int height = 50;
			int screenWidth = 800;
			int screenHeight = 600;

			Ball ball = new Ball(xCoordinate, yCoordinate, width, height, screenWidth, screenHeight);

			float oldXCoordinate = xCoordinate;
			float oldYCoordinate = yCoordinate;

			if (xCoordinate + width <= 0 || xCoordinate + width > screenWidth)
			{
				vx = vx * -1;
			}

            if (yCoordinate + height <= 0 || yCoordinate + height > screenHeight)
            {
                vy = vy * -1;
            }

			float expectedXCoordinate = oldXCoordinate + vx;
			float expectedYCoordinate = oldYCoordinate + vy;

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