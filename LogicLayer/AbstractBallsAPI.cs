﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    internal interface AbstractBallsAPI
    {
        public abstract void SummonBalls(int amount);
        public void TickBalls();
        public List<Ball> GetAllBalls();
        public void ClearWindow();
    }
}
