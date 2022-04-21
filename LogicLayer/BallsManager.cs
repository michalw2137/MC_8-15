using System.Collections;
using Logic;


namespace Logic
{
    public class BallsManager : AbstractBallsAPI
    {
        private readonly int _windowWidth;
        private readonly int _windowHeight;
        private readonly int _Radius;
        private readonly List<Ball> _ballStorage = new();
        private int _ID = 0;

        public BallsManager(int windowWidth, int windowHeight)
        {
            _windowHeight = windowHeight;
            _windowWidth = windowWidth;
            _Radius = Math.Min(windowHeight, windowWidth) / 60;

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
            int xStep = 0;
            int yStep = 0;
            do
            {
                xStep = rnd.Next(-3, 3);
                yStep = rnd.Next(-3, 3);
            } while (xStep == 0 || yStep == 0);
            

            int xPos = rnd.Next(_Radius, _windowWidth - _Radius);
            int yPos = rnd.Next(_Radius, _windowHeight - _Radius);

           
            Ball newBall = new Ball(_ID, xPos, yPos, _Radius, xStep, yStep);
            _ballStorage.Add(newBall);
            _ID++;
            
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
            _ID = 0;
        }
    }
}