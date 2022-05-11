using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Data
{
    internal class Ball : IBall, INotifyPropertyChanged
    {
        internal Ball(int xPosition, int yPosition)
        {
            XPosition = xPosition;
            YPosition = yPosition;

            Radius = 15;
            mass = 10;
            speed = 5;

            Random rnd = new Random();
            dir = rnd.Next(0, 360);

        }


        override public void move()  
        {
            double angle = Math.PI * (dir) / 180.0;
            double vx = Math.Sin(angle) * speed;
            double vy = Math.Cos(angle) * speed;

            XPosition += (int)vx;
            YPosition += (int)vy;

            RaisePropertyChanged();
        }

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override event PropertyChangedEventHandler PropertyChanged;

        //private void BounceIfOnEdge(int width, int height)
        //{
        //    if (XPosition <= Radius)            // hit left edge, go right
        //    {
        //        //XVelocity = Math.Abs(XVelocity);
        //        dir = 360 - dir;
        //    }
        //    if (XPosition >= width - Radius)    // hit right edge, go left
        //    {
        //        //XVelocity = Math.Abs(XVelocity) * (-1);
        //        dir = 360 - dir; 
        //    }

        //    if (YPosition <= Radius)            // hit bottom edge, go up
        //    {
        //        //YVelocity = Math.Abs(YVelocity);
        //        dir = 180 - dir;
        //    }
        //    if (YPosition >= height - Radius)   // hit top edge, go down
        //    {
        //        //YVelocity = Math.Abs(YVelocity) * (-1);
        //        dir = 180 - dir;

        //    }
        //}

    }
}