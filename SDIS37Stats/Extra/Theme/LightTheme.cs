// -----------------------------------------------------------------------
// <copyright file="LightTheme.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Extra.Theme
{
    using System.Diagnostics.CodeAnalysis;
    using System.Drawing;

    /// <summary>
    /// Class to make the dark theme.
    /// </summary>
    public class LightTheme : ITheme
    {
        /// <inheritdoc/>
        public ITheme.EThemeType ThemeType => ITheme.EThemeType.Light;

        /// <inheritdoc/>
        public Color FirefighterAvailabilityListView_BackgroundColor => ColorPalette.White2;

        /// <inheritdoc/>
        public Color FirefighterAvailabilityListView_BackgroundColorItem => ColorPalette.White3;

        /// <inheritdoc/>
        public Color FirefighterAvailabilityListView_BackgroundList => ColorPalette.White2;

        /// <inheritdoc/>
        public Color Form_BackgroundColor => ColorPalette.White1;

        /// <inheritdoc/>
        public Color Form_BackgroundColorButton => ColorPalette.White3;

        /// <inheritdoc/>
        public Color Form_BackgroundColorTextbox => ColorPalette.White3;

        /// <inheritdoc/>
        public Color Form_FontColor => ColorPalette.Gray7;

        /// <inheritdoc/>
        public Color Graph_AxisColor => ColorPalette.Blue1;

        /// <inheritdoc/>
        public Color Graph_BackgroundColor => ColorPalette.White2;

        /// <inheritdoc/>
        public Color Graph_BackgroundGraphColor => ColorPalette.White2;

        /// <inheritdoc/>
        public Color Graph_MainColor => ColorPalette.White4;

        /// <inheritdoc/>
        public Color OperationListView_BackgroundColor => ColorPalette.White2;

        /// <inheritdoc/>
        public Color OperationListView_BackgroundColorHighlightItem => ColorPalette.Blue1;

        /// <inheritdoc/>
        public Color OperationListView_BackgroundColorItem => ColorPalette.White3;

        /// <inheritdoc/>
        public Color OperationListView_BackgroundColorList => ColorPalette.White2;

        /// <inheritdoc/>
        public Color OperationListView_FontColorHighlightItem => ColorPalette.White1;

        /// <inheritdoc/>
        public Color OperationListView_FontColorItem => ColorPalette.Gray7;

        /// <inheritdoc/>
        public Color SettingsButton_BackgroundColorWhenSelected => ColorPalette.Blue1;

        /// <inheritdoc/>
        public Color SettingsButton_DefaultBackgroundColor => ColorPalette.Transparent;

        /// <inheritdoc/>
        public Color SettingsForm_CheckBox_BackgroundColor => ColorPalette.White3;

        /// <inheritdoc/>
        public Color SettingsForm_ComboBox_BackgroundColor => ColorPalette.White3;

        /// <inheritdoc/>
        public Color SevenSegment_DarkColor => ColorPalette.White2;

        /// <inheritdoc/>
        public Color SevenSegment_LightColor => ColorPalette.Gray4;
    }
}
