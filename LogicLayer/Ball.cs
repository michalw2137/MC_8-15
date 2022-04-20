namespace Data
{
    public class Ball
    {
        private readonly int _ballID;
        public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int XStepSize { get; set; }
        public int YStepSize { get; set; }
        public int Radius { get; set; }
        public string Colour { get; }

        public Ball(int ID, int xPosition, int yPosition, int radius, int xStepSize, int yStepSize)
        {
            _ballID = ID;
            XPosition = xPosition;
            YPosition = yPosition;
            XStepSize = xStepSize;
            YStepSize = yStepSize;
            Radius = radius;
            Colour = "#1E5128";
        }

        public int GetID()
        {
            return _ballID;
        }
    }
}