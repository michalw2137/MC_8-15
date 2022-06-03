using Microsoft.VisualStudio.TestTools.UnitTesting;
using Data;
using Logic;
using System.Collections.Generic;
using System.IO;
using System;

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

        [TestMethod]
        public void LogFileCreateTest()
        {
            IBall ball = IBall.getBall(50, 50, 0);

            Logger log = new Logger(ball);
            Console.WriteLine(Path.GetTempPath() + "ballsLogs\\ball0.json");
            Assert.IsFalse(File.Exists(Path.GetTempPath() + "ballsLogs\\ball0.json"));
        }
        [TestMethod]
        public void LoggingTest()
        {
            IBall ball = IBall.getBall(1111, 22222, 1);
            ball.vx = 420;
            ball.vy = 2137;
            Logger log = new Logger(ball);
            log.log();
            string input = File.ReadAllText(Path.GetTempPath() + "ballsLogs\\ball1.json");
            Assert.AreNotEqual(input, "[\n  {\n    \"id\": 1,\n    \"XPosition\": 1111,\n    \"YPosition\": 22222,\n    \"Radius\": 15,\n    \"vx\": 420,\n    \"vy\": 2137,\n    \"mass\": 10.0\n  }\n]");
        }
    }
}
