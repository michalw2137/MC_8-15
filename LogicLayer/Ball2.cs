using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Logic.ILogic;

namespace Logic
{
    internal class Ball2 : IBall2
    {
        internal Ball2(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;

            Radius = 15;
        }
    }
}
