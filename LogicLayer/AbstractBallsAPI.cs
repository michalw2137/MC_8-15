namespace Logic
{
    public abstract class AbstractBallsAPI
    {
        public abstract class BallAPI
        {
            public int XPosition { get; set; }
            public int YPosition { get; set; }
            public int Radius { get; set; }
        };

        public static AbstractBallsAPI Create(int windowWidth, int windowHeight)
        {
            return new BallsManager(windowWidth, windowHeight);
        }

        public abstract void SummonBalls(int amount);

        public abstract void TickBalls();

        public abstract List<BallAPI> GetAllBalls();

        public abstract void ClearBalls();
    }
}
