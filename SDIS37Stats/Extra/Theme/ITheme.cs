// -----------------------------------------------------------------------
// <copyright file="ITheme.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Extra.Theme
{
    using System.Drawing;

    /// <summary>
    /// Interface used by the themes.
    /// </summary>
    public interface ITheme
    {
        /// <summary>
        /// Defines the type of theme.
        /// </summary>
        public enum EThemeType
        {
            /// <summary>
            /// Used by the dark theme.
            /// </summary>
            Dark,

            /// <summary>
            /// Used by the light theme.
            /// </summary>
            Light,
        }

        /// <summary>
        /// Gets the type of theme.
        /// </summary>
        public EThemeType ThemeType { get; }

        /// <summary>
        /// Gets the color to be used to the background color of forms.
        /// </summary>
        Color Form_BackgroundColor { get; }

        /// <summary>
        /// Gets the color to be used to the font color of forms.
        /// </summary>
        Color Form_FontColor { get; }

        /// <summary>
        /// Gets the color to be used to the background color of buttons in the forms.
        /// </summary>
        Color Form_BackgroundColorButton { get; }

        /// <summary>
        /// Gets the color to be used to the background color of textboxs in the forms.
        /// </summary>
        Color Form_BackgroundColorTextbox { get; }

        /// <summary>
        /// Gets the color to be used to the background of settings button.
        /// </summary>
        Color SettingsButton_DefaultBackgroundColor { get; }

        /// <summary>
        /// Gets the color to be used to the background of settings button when it is selected.
        /// </summary>
        Color SettingsButton_BackgroundColorWhenSelected { get; }

        /// <summary>
        /// Gets the color to be used to the background of controls that use a graphics.
        /// </summary>
        Color Graph_BackgroundColor { get; }

        /// <summary>
        /// Gets the color to be used to the background of graphics.
        /// </summary>
        Color Graph_BackgroundGraphColor { get; }

        /// <summary>
        /// Gets the color to be used to the axis of graphics.
        /// </summary>
        Color Graph_AxisColor { get; }

        /// <summary>
        /// Gets the color to be used to the main bar of graphics.
        /// </summary>
        Color Graph_MainColor { get; }

        /// <summary>
        /// Gets the color to be used to the controls that use a <see cref="Controls.Type.Statistics.OperationListView"/>.
        /// </summary>
        Color OperationListView_BackgroundColor { get; }

        /// <summary>
        /// Gets the color to be used to the background of lists.
        /// </summary>
        Color OperationListView_BackgroundColorList { get; }

        /// <summary>
        /// Gets the color to be used to the background of items.
        /// </summary>
        Color OperationListView_BackgroundColorItem { get; }

        /// <summary>
        /// Gets the color to be used to the font of items.
        /// </summary>
        Color OperationListView_FontColorItem { get; }

        /// <summary>
        /// Gets the color to be used to the background of items that must be highlighted.
        /// </summary>
        Color OperationListView_BackgroundColorHighlightItem { get; }

        /// <summary>
        /// Gets the color to be used to the font of items that must be highlighted.
        /// </summary>
        Color OperationListView_FontColorHighlightItem { get; }

        /// <summary>
        /// Gets the color to be used as the dark color of <see cref="Controls.Type.SevenSegment.SevenSegment"/> objects.
        /// </summary>
        Color SevenSegment_DarkColor { get; }

        /// <summary>
        /// Gets the color to be used as the light color of <see cref="Controls.Type.SevenSegment.SevenSegment"/> objects.
        /// </summary>
        Color SevenSegment_LightColor { get; }

        /// <summary>
        /// Gets the color to be used to the background of controls that use a <see cref="Controls.Type.Statistics.FirefighterAvailabilityListView"/>.
        /// </summary>
        Color FirefighterAvailabilityListView_BackgroundColor { get; }

        /// <summary>
        /// Gets the color to be used to the background of lists.
        /// </summary>
        Color FirefighterAvailabilityListView_BackgroundList { get; }

        /// <summary>
        /// Gets the color to be used to the background of items.
        /// </summary>
        Color FirefighterAvailabilityListView_BackgroundColorItem { get; }

        /// <summary>
        /// Gets the color to be used to the background of combo box in the settings forms.
        /// </summary>
        Color SettingsForm_ComboBox_BackgroundColor { get; }

        /// <summary>
        /// Gets the color to be used to the background of check box in the settings forms.
        /// </summary>
        Color SettingsForm_CheckBox_BackgroundColor { get; }
    }
}
