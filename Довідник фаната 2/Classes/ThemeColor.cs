using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Довідник_фаната_2
{
    class ThemeColor
    { 

        public static Color PrimariColor { get; set; }
        public static Color SecondaryColor { get; set; }
        public static List<string> ColorList = new List<string>
        {
            "#3F51B5",
            "#009688",
            "#FF5722",
            "#607D8B",
            "#FF9800",
            "#9C27B0",
            "#2196F3",
            "#EA676C",
            "#E41A4A",
            "#B71C46",
            "#FFBC42",
            "#D81159",
            "#8F2D56",
            "#218380",
            "#73D2DE",};

        public static Color ChangeColorBrightness (Color color, double Factor)
        {
            double red = color.R;
            double green = color.G;
            double blue = color.B;
            
            if (Factor<0)
            {
                Factor += 1;
                red *= Factor;
                green *= Factor;
                blue *= Factor;
            }
            else
            {
                red = (255 - red) * Factor + red;
                green = (255 - green) * Factor + green;
                blue = (255 - blue) * Factor + blue;
            }

            return Color.FromArgb(color.A, (byte)red, (byte)green, (byte)blue);
        }

    }
}
