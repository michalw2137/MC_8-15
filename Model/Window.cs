﻿using Data;
using LogicLayer;

namespace Presentation.Model
{
    public class Window
    {
        private readonly BallsManager _ballsManager;
        private int _width;
        private int _height;

        public void Tick()
        {
           _ballsManager.DoTick();
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
            _ballsManager.ClearMap();
        }
    }
}