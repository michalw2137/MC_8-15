using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public abstract class AbstractBallsAPI
    {
        public abstract class BallAPI { };

        public static AbstractBallsAPI Create(int windowWidth, int windowHeight)
        {
            return new BallsManager(windowWidth, windowHeight);
        }

        public abstract void SummonBalls(int amount);

        public abstract void TickBalls();

        public abstract List<BallAPI> GetAllBalls();

        public abstract void ClearWindow();
    }
}
