using Logic;
using System.Collections.Generic;

namespace Presentation.Model
{
    internal class Window
    {
        private readonly ILogic _ballsManager;
        private readonly int _width;
        private readonly int _height;

        internal Window(int width, int height)
        {
            _width = width;
            _height = height;
            _ballsManager = ILogic.Create(width, height);
        }

        internal List<IBall2> GetBalls()
        {
            return _ballsManager.GetAllBalls();
        }
        
        internal void CreateBalls(int amount) 
        {
            _ballsManager.SummonBalls(amount);
        }

        internal void ClearBalls()
        {
            _ballsManager.ClearBalls();
        }

       

    }
}