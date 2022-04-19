using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class Colour
    {
        private static readonly string[] _colour = { "#0000ff", "#66ff66", "#ff6600", "#800000", "#cc00cc",
                                                     "#00e600", "#006699", "#4dc3ff", "#8585e0", "#191966",
                                                     "#cc99ff", "#99ff99", "#006600", "#cc6600", "#663300" };
        public static string PickColour()
        {
            Random rnd = new Random();
            return _colour[rnd.Next(_colour.Length)];
        }
    }
}
