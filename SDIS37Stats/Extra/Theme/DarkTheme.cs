// -----------------------------------------------------------------------
// <copyright file="DarkTheme.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Extra.Theme
{
    using System.Drawing;
    using System.Xml;
    using System.Xml.Schema;

    /// <summary>
    /// Class to make the dark theme.
    /// </summary>
    public class DarkTheme : ITheme
    {
        /// <inheritdoc/>
        public ITheme.EThemeType ThemeType => ITheme.EThemeType.Dark;

        /// <inheritdoc/>
        public Color FirefighterAvailabilityListView_BackgroundColor => ColorPalette.Gray7;

        /// <inheritdoc/>
        public Color FirefighterAvailabilityListView_BackgroundColorItem => ColorPalette.Gray5;

        /// <inheritdoc/>
        public Color FirefighterAvailabilityListView_BackgroundList => ColorPalette.Gray6;

        /// <inheritdoc/>
        public Color Form_BackgroundColor => ColorPalette.Gray7;

        /// <inheritdoc/>
        public Color Form_BackgroundColorButton => ColorPalette.Gray6;

        /// <inheritdoc/>
        public Color Form_BackgroundColorTextbox => ColorPalette.Gray6;

        /// <inheritdoc/>
        public Color Form_FontColor => ColorPalette.White2;

        /// <inheritdoc/>
        public Color Graph_AxisColor => ColorPalette.Yellow1;

        /// <inheritdoc/>
        public Color Graph_BackgroundColor => ColorPalette.Gray7;

        /// <inheritdoc/>
        public Color Graph_BackgroundGraphColor => ColorPalette.Gray6;

        /// <inheritdoc/>
        public Color Graph_MainColor => ColorPalette.White2;

        /// <inheritdoc/>
        public Color OperationListView_BackgroundColor => ColorPalette.Gray7;

        /// <inheritdoc/>
        public Color OperationListView_BackgroundColorHighlightItem => ColorPalette.Yellow2;

        /// <inheritdoc/>
        public Color OperationListView_BackgroundColorItem => ColorPalette.Gray5;

        /// <inheritdoc/>
        public Color OperationListView_BackgroundColorList => ColorPalette.Gray6;

        /// <inheritdoc/>
        public Color OperationListView_FontColorHighlightItem => ColorPalette.Gray7;

        /// <inheritdoc/>
        public Color OperationListView_FontColorItem => ColorPalette.White2;

        /// <inheritdoc/>
        public Color SettingsButton_BackgroundColorWhenSelected => ColorPalette.Yellow2;

        /// <inheritdoc/>
        public Color SettingsButton_DefaultBackgroundColor => ColorPalette.Transparent;

        /// <inheritdoc/>
        public Color SettingsForm_CheckBox_BackgroundColor => ColorPalette.Gray6;

        /// <inheritdoc/>
        public Color SettingsForm_ComboBox_BackgroundColor => ColorPalette.Gray6;

        /// <inheritdoc/>
        public Color SevenSegment_DarkColor => ColorPalette.Gray6;

        /// <inheritdoc/>
        public Color SevenSegment_LightColor => ColorPalette.White2;

        /// <inheritdoc/>
        public XmlSchema GetSchema() => null;

        /// <inheritdoc/>
        public void ReadXml(XmlReader reader)
        {
        }

        /// <inheritdoc/>
        public void WriteXml(XmlWriter writer)
        {
            writer.WriteAttributeString("Type", this.ThemeType.ToString());
        }
    }
}
