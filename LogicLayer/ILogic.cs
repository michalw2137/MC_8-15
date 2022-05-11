using Data;

namespace Logic
{
    public abstract class ILogic
    {
        public object _lock = new object();

        public bool isMoving { get; set; }

        public List<Thread> threads;

        public static ILogic Create(int width, int height)
        {
            Box.width = width;
            Box.height = height;    
            return new BallsManager();
        }

        public abstract void SummonBalls(int amount);

        public abstract void createBalls(int amount);

        public abstract List<IBall2> GetAllBalls();

        public abstract List<IBall> GetOldBalls();

        public abstract void ClearBalls();

        public abstract void BounceIfOnEdge(IBall ball);
    }

    public abstract class IBall2
    {
        public static IBall2 Create(int x, int y)
        {
            return new Ball2(x, y);
        }
        virtual public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int Radius { get; set; }
    }
}
