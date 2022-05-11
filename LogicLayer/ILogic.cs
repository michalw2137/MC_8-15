using Data;

namespace Logic
{
    public abstract class ILogic
    {
        public List<Thread> threads;

        public static ILogic Create(int windowWidth, int windowHeight)
        {
            return new BallsManager(windowWidth, windowHeight);
        }


        public abstract void resolveCollisions();

        public abstract void SummonBalls(int amount);

        public abstract List<IBall2> GetAllBalls();

        public abstract void ClearBalls();



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
}
