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
        #region MainForm
        public static Bitmap SettingsPicture => new Bitmap(@"Extra\Image\PNG\Gear.png");
        #endregion

        #region Availabilities
        public static Bitmap NotAvailableImage => new Bitmap(@"Extra\Image\PNG\BlackCircle.png");

        public static Bitmap AvailableOnSite => new Bitmap(@"Extra\Image\PNG\GreenCircle.png");

        public static Bitmap Available5min => new Bitmap(@"Extra\Image\PNG\BlueCircle.png");

        public static Bitmap Available10min => new Bitmap(@"Extra\Image\PNG\PurpleCircle.png");

        public static Bitmap InIntervention => new Bitmap(@"Extra\Image\PNG\RedCircle.png");
        #endregion

        #region OperationType
        public static Bitmap OperationType_INC => new Bitmap(@"Extra\Image\PNG\YellowTriangle.png");

        public static Bitmap OperationType_SAP => new Bitmap(@"Extra\Image\PNG\RedCircleWithoutInterior.png");

        public static Bitmap OperationType_OD => new Bitmap(@"Extra\Image\PNG\BlueSquareWithoutInterior.png");

        public static Bitmap OperationType_Other => new Bitmap(@"Extra\Image\PNG\GreenSquare.png");
        #endregion
    }
}
