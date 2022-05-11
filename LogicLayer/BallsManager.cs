using Data;

namespace Logic
{
    internal class BallsManager : ILogic
    {
        internal  readonly int _windowWidth;
        internal  readonly int _windowHeight;
        internal  readonly int _Radius = 15;
        internal  readonly List<IBall> _ballStorage = new();

        public BallsManager(int windowWidth, int windowHeight)
        {
            _windowHeight = windowHeight;
            _windowWidth = windowWidth;

            SummonBalls(17);
            threads = new List<Thread>();

            foreach (IBall ball in _ballStorage)
            {
                Thread t = new Thread(() =>
                {
                    while (true)
                    {
                        ball.move();
                        BounceIfOnEdge(ball);
                        Thread.Sleep(5);
                    }
                });

                threads.Add(t);

            }


        }

        override public void SummonBalls(int amount)
        {
            Random rnd = new Random();
            for (int i = 0; i < amount; i++)
            {
                int xPos = rnd.Next(_Radius, _windowWidth - _Radius);
                int yPos = rnd.Next(_Radius, _windowHeight - _Radius);
                _ballStorage.Add(IBall.getBall(xPos, yPos));
            }
        }

        
        override public void resolveCollisions()
        {
            foreach (IBall ball in _ballStorage)
            {
                BounceIfOnEdge(ball);
            } 
                
        }

        private void BounceIfOnEdge(IBall ball)
        {
            if (ball.XPosition <= ball.Radius)            // hit left edge, go right
            {
                ball.dir = 360 - ball.dir;
            }
            if (ball.XPosition >= _windowWidth - ball.Radius)    // hit right edge, go left
            {
                ball.dir = 360 - ball.dir;
            }

            if (ball.YPosition <= ball.Radius)            // hit bottom edge, go up
            {
                ball.dir = 180 - ball.dir;
            }
            if (ball.YPosition >= _windowHeight - ball.Radius)   // hit top edge, go down
            {
                ball.dir = 180 - ball.dir;
            }
        }

        override public List<IBall2> GetAllBalls()
        {
            List<IBall2> list = new List<IBall2>(); 
            foreach (IBall ball in _ballStorage)
            {
                list.Add(new Ball2(ball.XPosition, ball.YPosition));
            }
            return list;
        }
        

        override public void ClearBalls()
        {
            _ballStorage.Clear();
        }


    }
}