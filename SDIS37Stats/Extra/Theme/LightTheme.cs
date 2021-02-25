namespace SDIS37Stats.Extra.Theme
{
    using System.Drawing;

    public class LightTheme : ITheme
    {
        public Color FirefighterAvailabilityListView_BackgroundColor() => ColorPalette.gray5;

        public Color FirefighterAvailabilityListView_BackgroundColorItem() => Color.Red;

        public Color FirefighterAvailabilityListView_BackgroundList() => Color.Aqua;

        public Color Form_BackgroundColor() => ColorPalette.white1;

        public Color Form_BackgroundColorButton() => ColorPalette.gray6;

        public Color Form_BackgroundColorTextbox() => ColorPalette.gray6;

        public Color Form_FontColor() => ColorPalette.debugColor;

        public Color Graph_AxisColor() => ColorPalette.gray7;

        public Color Graph_BackgroundColor() => ColorPalette.white1;

        public Color Graph_MainColor() => ColorPalette.debugColor;

        public Color OperationListView_BackgroundColor() => ColorPalette.gray6;

        public Color OperationListView_BackgroundColorHighlightItem() => ColorPalette.yellow2;

        public Color OperationListView_BackgroundColorItem() => ColorPalette.yellow2;

        public Color OperationListView_BackgroundColorList() => Color.Red;

        public Color OperationListView_FontColorHighlightItem() => ColorPalette.yellow2;

        public Color OperationListView_FontColorItem() => Color.Blue;

        public Color SettingsButton_BackgroundColorWhenSelected() => ColorPalette.yellow2;

        public Color SettingsButton_DefaultBackgroundColor() => ColorPalette.transparent;

        public Color SevenSegment_DarkColor() => ColorPalette.debugColor;

        public Color SevenSegment_LightColor() => ColorPalette.yellow1;
    }
}
