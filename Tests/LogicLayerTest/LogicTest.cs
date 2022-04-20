using LogicLayer;
using LogicLayer.Exceptions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.LogicTest
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void BallsManagerConstructorTest()
        {
            BallsManager ballsManager = new BallsManager(150, 100);
            Assert.AreEqual(ballsManager.GetWindowWidth(),150);
            Assert.AreEqual(ballsManager.GetWindowHeight(), 100);
            Assert.AreEqual(ballsManager.GetMinRadius(), 100 / 60);
            Assert.AreEqual(ballsManager.GetMaxRadius(), 150 / 30);

        }

        [TestMethod]
        public void GetBallByIDTest()
        {
            BallsManager ballsManager = new BallsManager(150, 100);
            ballsManager.CreateBall(0, 5, 5, 1, 1);
            ballsManager.CreateBall(1, 5, 5, 1, 1);
            ballsManager.CreateBall(2, 5, 5, 1, 1);

            Assert.IsTrue(ballsManager.CheckForExistingID(0));
            Assert.IsTrue(ballsManager.CheckForExistingID(1));
            Assert.IsTrue(ballsManager.CheckForExistingID(2));
            Assert.IsFalse(ballsManager.CheckForExistingID(3));

        }

        [TestMethod]
        public void BallsManagerStorageManagementTest()
        {
            BallsManager ballsManager = new BallsManager(150, 100);

            Assert.AreEqual(0, ballsManager.GetAllBalls().Count);

            ballsManager.CreateBall(0,5,5,10,10);
            Assert.AreEqual(1, ballsManager.GetAllBalls().Count);
            Assert.IsTrue(ballsManager.CheckForExistingID(0));
            Assert.IsFalse(ballsManager.CheckForExistingID(1));
            Assert.AreEqual(1, ballsManager.AutoID());

            ballsManager.ClearMap();
            Assert.AreEqual(0, ballsManager.GetAllBalls().Count);
        }

        [TestMethod]
        public void BallRandomGeneratorTest()
        {
            BallsManager ballsManager = new BallsManager(150, 100);

            ballsManager.GenerateRandomBall();
            ballsManager.GenerateRandomBall();
            ballsManager.GenerateRandomBall();

            Assert.AreEqual(3, ballsManager.GetAllBalls().Count);
            Assert.IsTrue(ballsManager.CheckForExistingID(1));
            Assert.IsTrue(ballsManager.CheckForExistingID(2));
            Assert.IsTrue(ballsManager.CheckForExistingID(3));

            Assert.ThrowsException<InvalidDataException>(() => ballsManager.GetBallByID(4));
            Assert.ThrowsException<InvalidDataException>(() => ballsManager.RemoveBallByID(4));

            ballsManager.ClearMap();
            Assert.AreEqual(0, ballsManager.GetAllBalls().Count);

            ballsManager.SummonBalls(5);
            Assert.AreEqual(5, ballsManager.GetAllBalls().Count);

            ballsManager.SummonBalls(3);
            Assert.AreEqual(5 + 3, ballsManager.GetAllBalls().Count);
        }

        [DataTestMethod]
        [DataRow(1,  51,  1,   1,   1)]                   // co tu sie dzieje
        [DataRow(1,  1,   51,  1,   1)]               // co tu sie dzieje
        [DataRow(1,  51,  51,  1,   1)]              // co tu sie dzieje
        [DataRow(1, -5,   5,   1,   1)]               // co tu sie dzieje
        [DataRow(1,  5,  -5,   1,   1)]               // co tu sie dzieje
        [DataRow(1, -5,  -5,   1,   1)]              // co tu sie dzieje
        [DataRow(1,  5,   5,  -51,  1)]              // co tu sie dzieje
        [DataRow(1,  5,   5,   1,  -51)]              // co tu sie dzieje
        [DataRow(1,  5,   5,  -51, -51)]            // co tu sie dzieje    to jest chyba wywolanie testu dla wielu parametrow i guess
        public void BallManagerExceptionTest(int ID,int XPosition, int YPosition, int xD, int yD)
        {
            BallsManager ballsManager = new BallsManager(50, 50);
            Assert.ThrowsException<InvalidDataException>(() => ballsManager.CreateBall(ID,XPosition, YPosition,xD,yD));
            Assert.AreEqual(0,ballsManager.GetAllBalls().Count);
        }

        [TestMethod]
        public void TickTest()
        {
            BallsManager ballsManager = new BallsManager(150, 100);
            //XY CORDS
            ballsManager.SummonBalls(2);
            int xCurrentPos = ballsManager.GetBallByID(1).XPosition;
            int xHeading = ballsManager.GetBallByID(1).XStepSize;

            int xPredictedPos = 0;
            int xPredictedHeading = 0;

            if (ballsManager.GetBallByID(1).XPosition
                + ballsManager.GetBallByID(1).XStepSize
                + ballsManager.GetMinRadius() > ballsManager.GetWindowWidth() || ballsManager.GetBallByID(1).XPosition
                + ballsManager.GetBallByID(1).XStepSize
                + ballsManager.GetMinRadius() < 2*ballsManager.GetBallByID(1).Radius)
            {
                xPredictedHeading = xHeading * (-1);
            }
            else
            {
                xPredictedHeading = xHeading;
            }
            xPredictedPos = xCurrentPos + xPredictedHeading;
            ballsManager.DoTick();
            Assert.AreEqual(ballsManager.GetBallByID(1).XPosition, xPredictedPos);

            int yCurrentPos = ballsManager.GetBallByID(1).YPosition;
            int yHeading = ballsManager.GetBallByID(1).YStepSize;

            int yPredictedPos = 0;
            int yPredictedHeading = 0;


            if (ballsManager.GetBallByID(1).YPosition
                + ballsManager.GetBallByID(1).YStepSize
                + ballsManager.GetMinRadius() > ballsManager.GetWindowHeight() || ballsManager.GetBallByID(1).YPosition
                + ballsManager.GetBallByID(1).YStepSize
                + ballsManager.GetMinRadius() < 2 * ballsManager.GetBallByID(1).Radius)
            {
                yPredictedHeading = yHeading * (-1);
            }
            else
            {
                yPredictedHeading = yHeading;
            }
            yPredictedPos = yCurrentPos + yPredictedHeading;
            ballsManager.DoTick();
            Assert.AreEqual(ballsManager.GetBallByID(1).YPosition, yPredictedPos);


        }
    }
}