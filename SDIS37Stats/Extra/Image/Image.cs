using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIS37Stats.Extra.Image
{
    public static class Image
    {
        public static Bitmap NotAvailableImage => new Bitmap(@"Extra\Image\PNG\BlackCircle.png");

        public static Bitmap AvailableOnSite => new Bitmap(@"Extra\Image\PNG\GreenCircle.png");

        public static Bitmap Available5min => new Bitmap(@"Extra\Image\PNG\BlueCircle.png");

        public static Bitmap Available10min => new Bitmap(@"Extra\Image\PNG\PurpleCircle.png");

        public static Bitmap InIntervention => new Bitmap(@"Extra\Image\PNG\RedCircle.png");
    }
}
