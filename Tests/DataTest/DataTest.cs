using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests.DataTest
{
    [TestClass]
    public class DataTest
    {
        [TestMethod]
        public void BallConstructorTest()
        {
            Ball ball = new Ball(0,0, 1,0, 2, 3);
            Assert.AreEqual(0, ball.XPosition);
            Assert.AreEqual(1, ball.YPosition);
            Assert.AreEqual(2, ball.XStepSize);
            Assert.AreEqual(3, ball.YStepSize);
            Assert.AreEqual(0, ball.Radius);
            Assert.AreEqual(0, ball.GetID());

        }

        [TestMethod]
        public void ObjectStorageTest()
        {
            ObjectStorage<Ball> objectStorage = new();

            Ball ball1 = new Ball(1,0, 1,0, 2, 3);
            objectStorage.AddBall(ball1);

            Assert.AreEqual(objectStorage.GetAllBalls().Count, 1);

            Ball ball2 = new Ball(2,0, 1,0, 2, 3);
            objectStorage.AddBall(ball2);

            Assert.AreEqual(objectStorage.GetAllBalls().Count, 2);

            objectStorage.RemoveBall(ball);

            Assert.AreEqual(objectStorage.GetAllBalls().Count, 1);

            objectStorage.ClearStorage();

            Assert.AreEqual(objectStorage.GetAllBalls().Count, 0);
        }

        [TestMethod]
        public void ColourTest()
        {
            Ball ball = new Ball(1, 0, 1, 0, 2, 3);
            Assert.IsTrue(ball.Colour != "");
            Assert.IsTrue(ball.Colour is not null);
        }
    }
}