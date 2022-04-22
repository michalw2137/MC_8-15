using Logic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Tests.DataTest
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void SummonBallsTest()
        {
            AbstractBallsAPI api = AbstractBallsAPI.Create(100, 100);

            api.SummonBalls(10);
            List<AbstractBallsAPI.BallAPI> balls = api.GetAllBalls();
            Assert.AreEqual(10, balls.Count);
        }

        [TestMethod]
        public void SummonBallsAwayFromEdgeTest()
        {
            AbstractBallsAPI api = AbstractBallsAPI.Create(100, 60);

            api.SummonBalls(1000);

            foreach (AbstractBallsAPI.BallAPI ball in api.GetAllBalls())
            {
                Assert.AreEqual(60/30, ball.Radius);

                Assert.IsTrue(ball.XPosition >= ball.Radius);
                Assert.IsTrue(ball.XPosition <= 100 - ball.Radius) ;

                Assert.IsTrue(ball.YPosition >= ball.Radius);
                Assert.IsTrue(ball.YPosition <= 60 - ball.Radius);
            }
        }

        [TestMethod]
        public void ClearBallsTest()
        {
            AbstractBallsAPI api = AbstractBallsAPI.Create(100, 100);

            api.SummonBalls(10);
            api.ClearBalls();
            List<AbstractBallsAPI.BallAPI> balls = api.GetAllBalls();
            Assert.AreEqual(0, balls.Count);
        }

        [TestMethod]
        public void BallsMoveTest()
        {
            AbstractBallsAPI api = AbstractBallsAPI.Create(100, 100);

            api.SummonBalls(100);
            List<AbstractBallsAPI.BallAPI> balls = api.GetAllBalls();

            int[] startingXs = new int[100];
            int[] startingYs = new int[100];
            for (int i=0; i < startingXs.Length; i++)
            {
                startingXs[i] = balls[i].XPosition;
                startingYs[i] = balls[i].YPosition;
            }
            api.TickBalls();
            for (int i = 0; i < startingXs.Length; i++)
            {
                Assert.IsTrue(startingXs[i] != balls[i].XPosition || startingYs[i] != balls[i].YPosition);
            }
        }

        [TestMethod]
        public void BallsDontLeaveWindowTest()
        {
            AbstractBallsAPI api = AbstractBallsAPI.Create(100, 50);

            api.SummonBalls(10);

            for (int i = 0; i < 1000; i++)
            {
                foreach (AbstractBallsAPI.BallAPI ball in api.GetAllBalls())
                {
                    Assert.IsTrue(ball.XPosition >= 0);
                    Assert.IsTrue(ball.XPosition <= 100);

                    Assert.IsTrue(ball.YPosition >= 0);
                    Assert.IsTrue(ball.YPosition <= 50);
                }
                api.TickBalls();
            }
            
        }

    }
}