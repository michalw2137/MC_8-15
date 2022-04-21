namespace Logic
{
    internal class BallsManager : AbstractBallsAPI
    {
        internal  readonly int _windowWidth;
        internal  readonly int _windowHeight;
        internal  readonly int _Radius;
        internal  readonly List<BallAPI> _ballStorage = new();

        public BallsManager(int windowWidth, int windowHeight)
        {
            _windowHeight = windowHeight;
            _windowWidth = windowWidth;
            _Radius = Math.Min(windowHeight, windowWidth) / 30;

        }


        private  void CreateBall() 
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

        override public void SummonBalls(int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                CreateBall();
            }
        }

        
        override public void TickBalls()
        {
            foreach (Ball ball in _ballStorage)
            {
                ball.MoveBallWithinBox(_windowWidth, _windowHeight);
            }
        }

        
        override public List<BallAPI> GetAllBalls()
        {
            return _ballStorage;
        }
        

        override public void ClearBalls()
        {
            _ballStorage.Clear();
        }
    }
}