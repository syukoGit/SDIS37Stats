// -----------------------------------------------------------------------
// <copyright file="DarkTheme.cs" company="SyukoTech">
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
    public class DarkTheme : ITheme
    {
        public ITheme.EThemeType ThemeType => ITheme.EThemeType.Dark;

        public Color FirefighterAvailabilityListView_BackgroundColor => ColorPalette.Gray7;

        public Color FirefighterAvailabilityListView_BackgroundColorItem => ColorPalette.Gray5;

        public Color FirefighterAvailabilityListView_BackgroundList => ColorPalette.Gray6;

        public Color Form_BackgroundColor => ColorPalette.Gray7;

        public Color Form_BackgroundColorButton => ColorPalette.Gray6;

        public Color Form_BackgroundColorTextbox => ColorPalette.Gray6;

        public Color Form_FontColor => ColorPalette.White2;

        public Color Graph_AxisColor => ColorPalette.Yellow1;

        public Color Graph_BackgroundColor => ColorPalette.Gray7;

        public Color Graph_BackgroundGraphColor => ColorPalette.Gray6;

        public Color Graph_MainColor => ColorPalette.White2;

        public Color OperationListView_BackgroundColor => ColorPalette.Gray7;

        public Color OperationListView_BackgroundColorHighlightItem => ColorPalette.Yellow2;

        public Color OperationListView_BackgroundColorItem => ColorPalette.Gray5;

        public Color OperationListView_BackgroundColorList => ColorPalette.Gray6;

        public Color OperationListView_FontColorHighlightItem => ColorPalette.Gray7;

        public Color OperationListView_FontColorItem => ColorPalette.White2;

        public Color SettingsButton_BackgroundColorWhenSelected => ColorPalette.Yellow2;

        public Color SettingsButton_DefaultBackgroundColor => ColorPalette.Transparent;

        public Color SettingsForm_CheckBox_BackgroundColor => ColorPalette.Gray6;

        public Color SettingsForm_ComboBox_BackgroundColor => ColorPalette.Gray6;

        public Color SevenSegment_DarkColor => ColorPalette.Gray6;

        public Color SevenSegment_LightColor => ColorPalette.White2;
    }
}
