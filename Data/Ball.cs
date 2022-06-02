using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Runtime.Serialization;

namespace Data
{
    internal class Ball : IBall, INotifyPropertyChanged
    {
        internal Ball(int xPosition, int yPosition, int ID)
        {
            XPosition = xPosition;
            YPosition = yPosition;
            id = ID;
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

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue(nameof(XPosition), XPosition);
        }

        public override event PropertyChangedEventHandler PropertyChanged;

        
    }
}