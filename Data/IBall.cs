using System.ComponentModel;

namespace Data
{
    public abstract class IBall 
    {
        public static IBall getBall(int x, int y)
        {
            return new Ball(x, y);
        }

        virtual public int XPosition { get; set; }
        public int YPosition { get; set; }
        public int Radius { get; set; }

        //public double dir { get; set; }
        public int vx { get; set; }
        public int vy { get; set; }

        //public double speed { get; set; }
        public double mass { get; set; }

        public abstract void move();

        public abstract event PropertyChangedEventHandler? PropertyChanged;


    }
}
