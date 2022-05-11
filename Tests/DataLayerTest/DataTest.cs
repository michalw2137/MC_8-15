using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Logic;
using System.Collections.Generic;

namespace Tests.DataLayerTest
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void PropertiesTest()
        {
            ILogic api = ILogic.Create(100, 100);
            api.SummonBalls(1);
            List<IBall> balls = api.GetOldBalls();

            Assert.IsTrue(balls[0].vx >= -3 && balls[0].vx <= 3);
            Assert.IsTrue(balls[0].vy >= -3 && balls[0].vy <= 3);
            Assert.AreEqual(balls[0].mass, 10);
            Assert.AreEqual(balls[0].Radius, 15);
        }

        [TestMethod]
        public void SpawningBallsInBoxTest()
        {
            ILogic api = ILogic.Create(100, 100);
            api.SummonBalls(1);
            List<IBall> balls = api.GetOldBalls();

            Assert.IsTrue(balls[0].XPosition <= 100);
            Assert.IsTrue(balls[0].YPosition <= 100);
        }

        [TestMethod]
        public void MoveTest()
        {
            ILogic api = ILogic.Create(100, 100);
            api.isMoving = true;
            api.SummonBalls(1);
            List<IBall> balls = api.GetOldBalls();
            
            balls[0].XPosition = 50;
            Assert.AreEqual(balls[0].XPosition, 50);
            balls[0].YPosition = 10;
            Assert.AreEqual(balls[0].YPosition, 10);
            balls[0].vx = 15;
            Assert.AreEqual(balls[0].vx, 15);
            balls[0].vy = 60;            
            Assert.AreEqual(balls[0].vy, 60);
            balls[0].move();
            Assert.AreEqual(balls[0].XPosition, 65);
            Assert.AreEqual(balls[0].YPosition, 70);
        }

        [TestMethod]
        public void BoxTest()
        {
            ILogic api = ILogic.Create(150, 100);
            Assert.AreEqual((int)Box.width, 150);
            Assert.AreEqual((int)Box.height, 100);
        }
    }
}
