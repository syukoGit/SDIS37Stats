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
        public static Bitmap SettingsPicture => new(@"Extra\Image\PNG\Gear.png");
        #endregion

        #region Availabilities
        public static Bitmap NotAvailableImage => new(@"Extra\Image\PNG\BlackCircle.png");

        public static Bitmap AvailableOnSite => new(@"Extra\Image\PNG\GreenCircle.png");

        public static Bitmap Available5min => new(@"Extra\Image\PNG\BlueCircle.png");

        public static Bitmap Available10min => new(@"Extra\Image\PNG\PurpleCircle.png");

        public static Bitmap InIntervention => new(@"Extra\Image\PNG\RedCircle.png");
        #endregion

        #region OperationType
        public static Bitmap OperationType_INC => new(@"Extra\Image\PNG\YellowTriangle.png");

        public static Bitmap OperationType_SAP => new(@"Extra\Image\PNG\RedCircleWithoutInterior.png");

        public static Bitmap OperationType_OD => new(@"Extra\Image\PNG\BlueSquareWithoutInterior.png");

        public static Bitmap OperationType_Other => new(@"Extra\Image\PNG\GreenSquare.png");
        #endregion

        #region WebServiceState
        public static Bitmap WebServiceState_NotStated => new(@"Extra\Image\PNG\LightGrayCircle.png");

        public static Bitmap WebServiceState_DataRetrieving => new(@"Extra\Image\PNG\BlueCircle.png");

        public static Bitmap WebServiceState_UpToDate => new(@"Extra\Image\PNG\GreenCircle.png");

        public static Bitmap WebServiceState_AttemptConnection => new(@"Extra\Image\PNG\PurpleCircle.png");

        public static Bitmap WebServiceState_FailedConnection => new(@"Extra\Image\PNG\RedCircleWithYellowExclamationMark.png");

        public static Bitmap WebServiceState_NoConnection => new(@"Extra\Image\PNG\RedCircle.png");

        public static Bitmap WebServiceState_Error => new(@"Extra\Image\PNG\RedCircle.png");
        #endregion
    }
}
