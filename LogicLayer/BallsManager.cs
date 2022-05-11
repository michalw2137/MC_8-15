using Data;

namespace Logic
{
    internal class BallsManager : ILogic
    {
        internal  readonly int _Radius = 15;
        internal  readonly List<IBall> _ballStorage = new();

        public void assignThreads()
        {
            threads = new List<Thread>();

            foreach (IBall ball in _ballStorage)
            {
                Thread t = new Thread(() =>
                {
                    while (isMoving)
                    {
                        ball.move();
                        BounceIfOnEdge(ball);
                        lock (_lock)
                        {
                            ResolveCollisionsWithBalls(ball);
                        }
                        //System.Diagnostics.Debug.WriteLine("Ball dir=" + ball.dir.ToString() + ", speed=" + ball.speed.ToString());
                        Thread.Sleep(5);
                    }
                });
                threads.Add(t);
            }
        }

        public override void SummonBalls(int amount)
        {
            createBalls(amount);
            assignThreads();

            if (!isMoving)
            {
                isMoving = true;
                foreach (Thread t in threads) 
                {
                    t.Start(); 
                }
            }
        }

        override public void createBalls(int amount)
        {
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                int xPos = rnd.Next(_Radius, Box.width - _Radius);
                int yPos = rnd.Next(_Radius, Box.height - _Radius);
                _ballStorage.Add(IBall.getBall(xPos, yPos));
            }
        }

        public override void BounceIfOnEdge(IBall ball)
        {
            if (ball.XPosition <= ball.Radius)            // hit left edge, go right
            {
                ball.vx = Math.Abs(ball.vx);
            }
            if (ball.XPosition >= Box.width - ball.Radius)    // hit right edge, go left
            {
                ball.vx = Math.Abs(ball.vx) * (-1);
            }

            if (ball.YPosition <= ball.Radius)            // hit bottom edge, go up
            {
                ball.vy = Math.Abs(ball.vy);
            }
            if (ball.YPosition >= Box.height - ball.Radius)   // hit top edge, go down
            {
                ball.vy = Math.Abs(ball.vy) * (-1);
            }
        }

        private void ResolveCollisionsWithBalls(IBall ball)
        {
            IBall? collided = FindCollidingBall(ball);
            if (collided != null)
            {
                double newX1, newX2, newY1, newY2;

                newX1 = (ball.vx * (ball.mass - collided.mass) / (ball.mass + collided.mass) + (2 * collided.mass * collided.vx) / (ball.mass + collided.mass));
                newY1 = (ball.vy * (ball.mass - collided.mass) / (ball.mass + collided.mass) + (2 * collided.mass * collided.vy) / (ball.mass + collided.mass));

                newX2 = (collided.vx * (collided.mass - ball.mass) / (ball.mass + collided.mass) + (2 * ball.mass * ball.vx) / (ball.mass + collided.mass));
                newY2 = (collided.vy * (collided.mass - ball.mass) / (ball.mass + collided.mass) + (2 * ball.mass * ball.vy) / (ball.mass + collided.mass));

                ball.vx = (int)newX1;
                ball.vy = (int)newY1;
                collided.vx = (int)newX2;
                collided.vy = (int)newY2;
            }
        }

        private IBall? FindCollidingBall(IBall ball)
        {
            foreach (IBall other in _ballStorage)
            {
                if (other == ball)
                    continue;
                double distance = Math.Sqrt(Math.Pow((ball.XPosition + ball.vx - other.XPosition + other.vx), 2) +
                                            Math.Pow((ball.YPosition + ball.vy - other.YPosition + other.vy), 2));
                if (distance <= ball.Radius + other.Radius)
                    return other;
            }
            return null;
        }

        public override void ClearBalls()
        {
            isMoving = false;
            threads.Clear();
            _ballStorage.Clear();
        }

        override public List<IBall2> GetAllBalls()
        {
            List<IBall2> list = new (); 
            foreach (IBall ball in _ballStorage)
            {
                list.Add(new Ball2(ball.XPosition, ball.YPosition));
            }
            return list;
        }
        override public List<IBall> GetOldBalls()
        {
            List<IBall> list = new();
            foreach (IBall ball in _ballStorage)
            {
                list.Add(ball);
            }
            return list;
        }

    }
}