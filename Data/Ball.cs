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
            Random rnd = new Random();
            do
            {
                vx = rnd.Next(-3, 3);
                vy = rnd.Next(-3, 3);
            } while (vx == 0 || vy == 0);
        }

        override public void move()  
        {

            XPosition += vx;
            YPosition += vy;

            RaisePropertyChanged();
        }

        private void RaisePropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override event PropertyChangedEventHandler PropertyChanged;


    }
}