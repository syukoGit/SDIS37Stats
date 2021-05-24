// -----------------------------------------------------------------------
// <copyright file="Image.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Extra.Image
{
    using System.Drawing;

    /// <summary>
    /// Class for gets the images used by the software.
    /// </summary>
    public static class Image
    {
        /// <summary>
        /// Gets the picture that represents the settings.
        /// </summary>
        public static Bitmap SettingsPicture => new (@"Extra\Image\PNG\Gear.png");

        /// <summary>
        /// Gets the picture that represents the firefighter's availability when it is "not available".
        /// </summary>
        public static Bitmap FirefighterAvailability_NotAvailable => new (@"Extra\Image\PNG\BlackCircle.png");

        /// <summary>
        /// Gets the picture that represents the firefighter's availability when it is "available on site".
        /// </summary>
        public static Bitmap FirefighterAvailability_AvailableOnSite => new (@"Extra\Image\PNG\GreenCircle.png");

        /// <summary>
        /// Gets the picture that represents the firefighter's availability when it is "available at 5 minutes".
        /// </summary>
        public static Bitmap FirefighterAvailability_Available5min => new (@"Extra\Image\PNG\BlueCircle.png");

        /// <summary>
        /// Gets the picture that represents the firefighter's availability when it is "available at 10 minutes".
        /// </summary>
        public static Bitmap FirefighterAvailability_Available10min => new (@"Extra\Image\PNG\PurpleCircle.png");

        /// <summary>
        /// Gets the picture that represents the firefighter's availability when it is "in intervention".
        /// </summary>
        public static Bitmap FirefighterAvailability_InIntervention => new (@"Extra\Image\PNG\RedCircle.png");

        /// <summary>
        /// Gets the picture that represents the operation type when it is "fire".
        /// </summary>
        public static Bitmap OperationType_INC => new (@"Extra\Image\PNG\YellowTriangle.png");

        /// <summary>
        /// Gets the picture that represents the operation type when it is "personal assistance".
        /// </summary>
        public static Bitmap OperationType_SAP => new (@"Extra\Image\PNG\RedCircleWithoutInterior.png");

        /// <summary>
        /// Gets the picture that represents the operation type when it is "diverse operation".
        /// </summary>
        public static Bitmap OperationType_OD => new (@"Extra\Image\PNG\BlueSquareWithoutInterior.png");

        /// <summary>
        /// Gets the picture that represents the operation type when it is "other operation".
        /// </summary>
        public static Bitmap OperationType_Other => new (@"Extra\Image\PNG\GreenSquare.png");

        /// <summary>
        /// Gets the picture that represents the web service state when it is "not stated".
        /// </summary>
        public static Bitmap WebServiceState_NotStated => new (@"Extra\Image\PNG\LightGrayCircle.png");

        /// <summary>
        /// Gets the picture that represents the web service state when it is "data retrieving".
        /// </summary>
        public static Bitmap WebServiceState_DataRetrieving => new (@"Extra\Image\PNG\BlueCircle.png");

        /// <summary>
        /// Gets the picture that represents the web service state when it is "up to date".
        /// </summary>
        public static Bitmap WebServiceState_UpToDate => new (@"Extra\Image\PNG\GreenCircle.png");

        /// <summary>
        /// Gets the picture that represents the web service state when it is "attempt connection".
        /// </summary>
        public static Bitmap WebServiceState_AttemptConnection => new (@"Extra\Image\PNG\PurpleCircle.png");

        /// <summary>
        /// Gets the picture that represents the web service state when it is "failed connection".
        /// </summary>
        public static Bitmap WebServiceState_FailedConnection => new (@"Extra\Image\PNG\RedCircleWithYellowExclamationMark.png");

        /// <summary>
        /// Gets the picture that represents the web service state when it is "no connection".
        /// </summary>
        public static Bitmap WebServiceState_NoConnection => new (@"Extra\Image\PNG\RedCircle.png");

        /// <summary>
        /// Gets the picture that represents the web service state when it is "error".
        /// </summary>
        public static Bitmap WebServiceState_Error => new (@"Extra\Image\PNG\RedCircle.png");
    }
}
