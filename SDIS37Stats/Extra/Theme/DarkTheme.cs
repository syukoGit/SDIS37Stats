using System.Drawing;

namespace SDIS37Stats.Extra.Theme
{
    public class DarkTheme : ITheme
    {
        public ITheme.EThemeType ThemeType => ITheme.EThemeType.Dark;

        public Color FirefighterAvailabilityListView_BackgroundColor() => ColorPalette.gray7;

        public Color FirefighterAvailabilityListView_BackgroundColorItem() => ColorPalette.gray5;

        public Color FirefighterAvailabilityListView_BackgroundList() => ColorPalette.gray6;

        public Color Form_BackgroundColor() => ColorPalette.gray7;

        public Color Form_BackgroundColorButton() => ColorPalette.gray6;

        public Color Form_BackgroundColorTextbox() => ColorPalette.gray6;

        public Color Form_FontColor() => ColorPalette.white2;

        public Color Graph_AxisColor() => ColorPalette.yellow1;

        public Color Graph_BackgroundColor() => ColorPalette.gray7;

        public Color Graph_BackgroundGraphColor() => ColorPalette.gray6;

        public Color Graph_MainColor() => ColorPalette.white2;

        public Color OperationListView_BackgroundColor() => ColorPalette.gray7;

        public Color OperationListView_BackgroundColorHighlightItem() => ColorPalette.yellow2;

        public Color OperationListView_BackgroundColorItem() => ColorPalette.gray5;

        public Color OperationListView_BackgroundColorList() => ColorPalette.gray6;

        public Color OperationListView_FontColorHighlightItem() => ColorPalette.gray7;

        public Color OperationListView_FontColorItem() => ColorPalette.white2;

        public Color SettingsButton_BackgroundColorWhenSelected() => ColorPalette.yellow2;

        public Color SettingsButton_DefaultBackgroundColor() => ColorPalette.transparent;

        public Color SettingsForm_CheckBox_BackgroundColor() => ColorPalette.gray6;

        public Color SettingsForm_ComboBox_BackgroundColor() => ColorPalette.gray6;

        public Color SevenSegment_DarkColor() => ColorPalette.gray6;

        public Color SevenSegment_LightColor() => ColorPalette.white2;
    }
}
