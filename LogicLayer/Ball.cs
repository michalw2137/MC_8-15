namespace Logic
{
    internal class Ball : AbstractBallsAPI.BallAPI
    {
        private int XVelocity { get; set; }
        private int YVelocity { get; set; }
        private int dir { get; set; }
        private float speed { get; set; }

        internal Ball(int xPosition, int yPosition, int radius, int xVelocity, int yVelocity)
        {
            XPosition = xPosition;
            YPosition = yPosition;

            XVelocity = xVelocity;
            YVelocity = yVelocity;

            Radius = radius;

            Random rnd = new Random();
            dir = rnd.Next(0, 360);

            speed = 5;
            //speed = rnd.Next(2, 10);
        }

        internal void MoveBallWithinBox(int width, int height)
        {
            double angle = Math.PI * (dir) / 180.0;
            double vx = Math.Sin(angle) * speed;
            double vy = Math.Cos(angle) * speed;

            XPosition += (int)vx;
            YPosition += (int)vy;

            BounceIfOnEdge(width, height);
            //int x = 0, y = 0;
            //bool moved = true;
            //while (moved)
            //{
            //    moved = false;
            //    if (x < Math.Abs(XVelocity))
            //    {
            //        XPosition += XVelocity / Math.Abs(XVelocity); // -1 if Vel<0, 1 if Vel>0, Vel=0 while will not happen
            //        x++;
            //        moved = true;

            //    }
            //    if (y < Math.Abs(YVelocity))
            //    {
            //        YPosition += YVelocity / Math.Abs(YVelocity); // -1 if Vel<0, 1 if Vel>0, Vel=0 while will not happen
            //        y++;
            //        moved = true;

            //    }
            //    BounceIfOnEdge(width, height);
            //}
        }

        private void BounceIfOnEdge(int width, int height)
        {
            if (XPosition <= Radius)            // hit left edge, go right
            {
                //XVelocity = Math.Abs(XVelocity);
                dir = 90;
            }
            if (XPosition >= width - Radius)    // hit right edge, go left
            {
                //XVelocity = Math.Abs(XVelocity) * (-1);
                dir = -90; 
            }

            if (YPosition <= Radius)            // hit bottom edge, go up
            {
                //YVelocity = Math.Abs(YVelocity);
                dir = 0;
            }
            if (YPosition >= height - Radius)   // hit top edge, go down
            {
                //YVelocity = Math.Abs(YVelocity) * (-1);
                //dir -= 2 * (dir - 270);
                dir = 180;

            }
        }

    }
}