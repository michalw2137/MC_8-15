using System.Collections;
using Logic;


namespace Logic
{
    public class BallsManager : IAbstractBallsAPI
    {
        private readonly int _windowWidth;
        private readonly int _windowHeight;

        private readonly int _Radius;

        private readonly List<Ball> _ballStorage = new();

        public BallsManager(int windowWidth, int windowHeight)
        {
            _windowHeight = windowHeight;
            _windowWidth = windowWidth;
            _Radius = Math.Min(windowHeight, windowWidth) / 30;

        }

        public int GetWindowWidth()
        {
            return _windowWidth;
        }

        public int GetWindowHeight()
        {
            return _windowHeight;
        }

        public int GetRadius()
        {
            return _Radius;
        }

        public void CreateBall() 
        {
            Random rnd = new Random();
            int xVelocity, yVelocity;
            int speed = 6;
            do
            {
                xVelocity = rnd.Next(-speed, speed);
                yVelocity = rnd.Next(-speed, speed);
            } 
            while (xVelocity == 0 || yVelocity == 0);
            
            int xPos = rnd.Next(_Radius, _windowWidth - _Radius);
            int yPos = rnd.Next(_Radius, _windowHeight - _Radius);

            Ball newBall = new(xPos, yPos, _Radius, xVelocity, yVelocity);
            _ballStorage.Add(newBall);           
        }

        public void SummonBalls(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                CreateBall();
            }
        }

        public void TickBalls()
        {
            foreach (Ball ball in GetAllBalls())
            {
                ball.MoveBallWithinBox(_windowWidth, _windowHeight);
            }
        }

        public List<Ball> GetAllBalls()
        {
            return _ballStorage;
        }

        public void ClearWindow()
        {
            _ballStorage.Clear();
        }
    }
}