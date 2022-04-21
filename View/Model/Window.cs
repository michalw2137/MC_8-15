using Logic;
using System.Collections.Generic;

namespace Presentation.Model
{
    public class Window
    {
        private readonly AbstractBallsAPI _ballsManager;
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
            _ballsManager = AbstractBallsAPI.Create(width, height);
        }

        
        public List<AbstractBallsAPI.BallAPI> GetBalls()
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