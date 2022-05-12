using Logic;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System;
using Moq;

namespace Tests.LogicLayerTest
{
    [TestClass]
    public class LogicTest
    {
        [TestMethod]
        public void SummonBallsTest()
        {
            ILogic api = ILogic.Create(100, 100);

            api.SummonBalls(10);
            List<IBall2> balls = api.GetAllBalls();
            Assert.AreEqual(10, balls.Count);
        }

        [TestMethod]
        public void ClearBallsTest()
        {
            ILogic api = ILogic.Create(100, 100);

            api.SummonBalls(10);
            api.ClearBalls();
            List<IBall2> balls = api.GetAllBalls();
            Assert.AreEqual(0, balls.Count);
        }

        [TestMethod]
        public void Ball2Test()
        {
            ILogic api = ILogic.Create(100, 100);
            api.SummonBalls(1);
            List<IBall2> balls = api.GetAllBalls();
            balls[0].Radius = 69;
            balls[0].XPosition = 2137;
            balls[0].YPosition = 420;

            Assert.AreEqual(balls[0].Radius, 69);
            Assert.AreEqual(balls[0].XPosition, 2137);
            Assert.AreEqual(balls[0].YPosition, 420);
        }

        [TestMethod]
        public void BounceTest()
        {
            ILogic api = ILogic.Create(100, 100);
            api.SummonBalls(1);
            List<IBall> balls = api.GetOldBalls();
            balls[0].XPosition = 95;
            int temp = balls[0].vx;
            api.BounceIfOnEdge(balls[0]);
            Assert.AreEqual(Math.Abs(temp) * (-1), balls[0].vx);
        }


    }
}