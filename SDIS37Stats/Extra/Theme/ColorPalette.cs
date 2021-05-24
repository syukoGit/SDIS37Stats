// -----------------------------------------------------------------------
// <copyright file="ColorPalette.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Extra.Theme
{
    using System.Drawing;

    /// <summary>
    /// Class that contains the colors used by the themes.
    /// </summary>
    public static class ColorPalette
    {
        /// <summary>
        /// Gets a gray color with the red value to 64, the green value to 64 and the blue value to 64.
        /// </summary>
        public static Color Gray7 { get; } = Color.FromArgb(64, 64, 64);

        /// <summary>
        /// Gets a gray color with the red value to 75, the green value to 75 and the blue value to 75.
        /// </summary>
        public static Color Gray6 { get; } = Color.FromArgb(75, 75, 75);

        /// <summary>
        /// Gets a gray color with the red value to 100, the green value to 100 and the blue value to 100.
        /// </summary>
        public static Color Gray5 { get; } = Color.FromArgb(100, 100, 100);

        /// <summary>
        /// Gets a gray color with the red value to 120, the green value to 120 and the blue value to 120.
        /// </summary>
        public static Color Gray4 { get; } = Color.FromArgb(120, 120, 120);

        /// <summary>
        /// Gets a white color with the red value to 255, the green value to 255 and the blue value to 255.
        /// </summary>
        public static Color White1 { get; } = Color.FromArgb(255, 255, 255);

        /// <summary>
        /// Gets a white color with the red value to 240, the green value to 240 and the blue value to 240.
        /// </summary>
        public static Color White2 { get; } = Color.FromArgb(240, 240, 240);

        /// <summary>
        /// Gets a white color with the red value to 224, the green value to 224 and the blue value to 224.
        /// </summary>
        public static Color White3 { get; } = Color.FromArgb(224, 224, 224);

        /// <summary>
        /// Gets a white color with the red value to 200, the green value to 200 and the blue value to 200.
        /// </summary>
        public static Color White4 { get; } = Color.FromArgb(200, 200, 200);

        /// <summary>
        /// Gets a yellow color with the red value to 220, the green value to 220 and the blue value to 0.
        /// </summary>
        public static Color Yellow1 { get; } = Color.FromArgb(220, 220, 0);

        /// <summary>
        /// Gets a yellow color with the red value to 255, the green value to 255 and the blue value to 180.
        /// </summary>
        public static Color Yellow2 { get; } = Color.FromArgb(255, 255, 180);

        /// <summary>
        /// Gets a blue color with the red value to 51, the green value to 153 and the blue value to 255.
        /// </summary>
        public static Color Blue1 { get; } = Color.FromArgb(51, 153, 255);

        /// <summary>
        /// Gets a transparent color.
        /// </summary>
        public static Color Transparent { get; } = Color.Transparent;

        /// <summary>
        /// Gets a gray color with the red value to 0, the green value to 80 and the blue value to 0.
        /// </summary>
        public static Color DebugColor { get; } = Color.Green;
    }
}
