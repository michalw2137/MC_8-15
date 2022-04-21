namespace Logic
{
    public class Ball
    {
        private readonly int _ballID;
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public int XVelocity { get; set; }
        public int YVelocity { get; set; }

        public int Radius { get; set; }
        public string Colour { get; }

        public Ball(int ID, int xPosition, int yPosition, int radius, int xStepSize, int yStepSize)
        {
            _ballID = ID;
            XPosition = xPosition;
            YPosition = yPosition;
            XVelocity = xStepSize;
            YVelocity = yStepSize;
            Radius = radius;
            Colour = "#1E5128";
        }

        public int GetID()
        {
            return _ballID;
        }

        public void MoveBallWithinBox(int width, int height)
        {
            int x = 0, y = 0;
            bool moved = true;
            while (moved)
            {
                moved = false;
                if (x < Math.Abs(XVelocity))
                {
                    XPosition += XVelocity / Math.Abs(XVelocity); // -1 if Vel<0, 1 if Vel>0, Vel=0 while will not happen
                    x++;
                    moved = true;

                }
                if (y < Math.Abs(YVelocity))
                {
                    YPosition += YVelocity / Math.Abs(YVelocity); // -1 if Vel<0, 1 if Vel>0, Vel=0 while will not happen
                    y++;
                    moved = true;

                }
                bounceIfOnEdge(width, height);
            }
        }

        private void bounceIfOnEdge(int width, int height)
        {
            if (XPosition <= Radius)
            {
                XVelocity = Math.Abs(XVelocity);
            }
            if (XPosition >= width - Radius)
            {
                XVelocity = Math.Abs(XVelocity) * (-1);
            }

            if (YPosition <= Radius)
            {
                YVelocity = Math.Abs(YVelocity);
            }
            if (YPosition >= height - Radius)
            {
                YVelocity = Math.Abs(YVelocity) * (-1);
            }
        }

    }
}