namespace SDIS37Stats.Extra.Theme
{
    using System.Drawing;

    public class LightTheme : ITheme
    {
        public ITheme.EThemeType ThemeType => ITheme.EThemeType.Light;

        public Color FirefighterAvailabilityListView_BackgroundColor() => ColorPalette.white2;

        public Color FirefighterAvailabilityListView_BackgroundColorItem() => ColorPalette.white3;

        public Color FirefighterAvailabilityListView_BackgroundList() => ColorPalette.white2;

        public Color Form_BackgroundColor() => ColorPalette.white1;

        public Color Form_BackgroundColorButton() => ColorPalette.white3;

        public Color Form_BackgroundColorTextbox() => ColorPalette.white3;

        public Color Form_FontColor() => ColorPalette.gray7;

        public Color Graph_AxisColor() => ColorPalette.blue1;

        public Color Graph_BackgroundColor() => ColorPalette.white2;

        public Color Graph_BackgroundGraphColor() => ColorPalette.white2;

        public Color Graph_MainColor() => ColorPalette.white4;

        public Color OperationListView_BackgroundColor() => ColorPalette.white2;

        public Color OperationListView_BackgroundColorHighlightItem() => ColorPalette.blue1;

        public Color OperationListView_BackgroundColorItem() => ColorPalette.white3;

        public Color OperationListView_BackgroundColorList() => ColorPalette.white2;

        public Color OperationListView_FontColorHighlightItem() => ColorPalette.white1;

        public Color OperationListView_FontColorItem() => ColorPalette.gray7;

        public Color SettingsButton_BackgroundColorWhenSelected() => ColorPalette.blue1;

        public Color SettingsButton_DefaultBackgroundColor() => ColorPalette.transparent;

        public Color SettingsForm_CheckBox_BackgroundColor() => ColorPalette.white3;

        public Color SettingsForm_ComboBox_BackgroundColor() => ColorPalette.white3;

        public Color SevenSegment_DarkColor() => ColorPalette.white2;

        public Color SevenSegment_LightColor() => ColorPalette.gray4;
    }
}
