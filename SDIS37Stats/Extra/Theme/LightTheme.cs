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
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented", Justification = "Reviewed.")]
    public class LightTheme : ITheme
    {
        public ITheme.EThemeType ThemeType => ITheme.EThemeType.Light;

        public Color FirefighterAvailabilityListView_BackgroundColor => ColorPalette.White2;

        public Color FirefighterAvailabilityListView_BackgroundColorItem => ColorPalette.White3;

        public Color FirefighterAvailabilityListView_BackgroundList => ColorPalette.White2;

        public Color Form_BackgroundColor => ColorPalette.White1;

        public Color Form_BackgroundColorButton => ColorPalette.White3;

        public Color Form_BackgroundColorTextbox => ColorPalette.White3;

        public Color Form_FontColor => ColorPalette.Gray7;

        public Color Graph_AxisColor => ColorPalette.Blue1;

        public Color Graph_BackgroundColor => ColorPalette.White2;

        public Color Graph_BackgroundGraphColor => ColorPalette.White2;

        public Color Graph_MainColor => ColorPalette.White4;

        public Color OperationListView_BackgroundColor => ColorPalette.White2;

        public Color OperationListView_BackgroundColorHighlightItem => ColorPalette.Blue1;

        public Color OperationListView_BackgroundColorItem => ColorPalette.White3;

        public Color OperationListView_BackgroundColorList => ColorPalette.White2;

        public Color OperationListView_FontColorHighlightItem => ColorPalette.White1;

        public Color OperationListView_FontColorItem => ColorPalette.Gray7;

        public Color SettingsButton_BackgroundColorWhenSelected => ColorPalette.Blue1;

        public Color SettingsButton_DefaultBackgroundColor => ColorPalette.Transparent;

        public Color SettingsForm_CheckBox_BackgroundColor => ColorPalette.White3;

        public Color SettingsForm_ComboBox_BackgroundColor => ColorPalette.White3;

        public Color SevenSegment_DarkColor => ColorPalette.White2;

        public Color SevenSegment_LightColor => ColorPalette.Gray4;
    }
}
