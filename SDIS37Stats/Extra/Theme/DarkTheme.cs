using System.Drawing;

namespace SDIS37Stats.Extra.Theme
{
    public class DarkTheme : ITheme
    {
        public Color FirefighterAvailabilityListView_BackgroundColorItem() => ColorPalette.gray5;

        public Color FirefighterAvailabilityListView_BackgroundList() => ColorPalette.gray6;

        public Color Form_BackgroundColor() => ColorPalette.gray7;

        public Color Form_BackgroundColorButton() => ColorPalette.gray6;

        public Color Form_BackgroundColorTextbox() => ColorPalette.gray6;

        public Color Form_FontColor() => ColorPalette.white1;

        public Color Graph_AxisColor() => ColorPalette.yellow1;

        public Color Graph_BackgroundColor() => ColorPalette.gray6;

        public Color Graph_MainColor() => ColorPalette.white1;

        public Color OperationListView_BackgroundColorHighlightItem() => ColorPalette.yellow2;

        public Color OperationListView_BackgroundColorItem() => ColorPalette.gray5;

        public Color OperationListView_BackgroundColorList() => ColorPalette.gray6;

        public Color OperationListView_FontColorHighlightItem() => ColorPalette.yellow2;

        public Color OperationListView_FontColorItem() => ColorPalette.white1;

        public Color SettingsButton_BackgroundColorWhenSelected() => ColorPalette.yellow2;

        public Color SettingsButton_DefaultBackgroundColor() => ColorPalette.transparent;

        public Color SevenSegment_DarkColor() => ColorPalette.gray6;

        public Color SevenSegment_LightColor() => ColorPalette.white1;
    }
}
