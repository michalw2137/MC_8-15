using Logic;
using System.Collections.Generic;

namespace Presentation.Model
{
    public class Window
    {
        private readonly BallsManager _ballsManager;
        private readonly int _width;
        private readonly int _height;

        public void TickBalls()
        {
           _ballsManager.TickBalls();
        }

        public Window(int width, int height)
        {
            _width = width;
            _height = height;
            _ballsManager = new BallsManager(width, height);
        }

        public List<Ball> GetBalls()
        {
            return _ballsManager.GetAllBalls();
        }

        public void CreateBalls(int amount) 
        {
            _ballsManager.SummonBalls(amount);
        }

        public void ClearWindow()
        {
            _ballsManager.ClearWindow();
        }
    }
}