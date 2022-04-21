namespace Logic
{
    public class Ball
    {
        public int XPosition { get; set; }
        public int YPosition { get; set; }

        public int XVelocity { get; set; }
        public int YVelocity { get; set; }

        public int Radius { get; set; }
        public string Colour { get; }

        public Ball(int xPosition, int yPosition, int radius, int xVelocity, int yVelocity)
        {
            XPosition = xPosition;
            YPosition = yPosition;

            XVelocity = xVelocity;
            YVelocity = yVelocity;

            Radius = radius;
            Colour = "#fc0352";
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
                BounceIfOnEdge(width, height);
            }
        }

        private void BounceIfOnEdge(int width, int height)
        {
            if (XPosition <= Radius)            // hit left edge, go right
            {
                XVelocity = Math.Abs(XVelocity);
            }
            if (XPosition >= width - Radius)    // hit right edge, go left
            {
                XVelocity = Math.Abs(XVelocity) * (-1);
            }

            if (YPosition <= Radius)            // hit bottom edge, go up
            {
                YVelocity = Math.Abs(YVelocity);
            }
            if (YPosition >= height - Radius)   // hit top edge, go down
            {
                YVelocity = Math.Abs(YVelocity) * (-1);
            }
        }

    }
}