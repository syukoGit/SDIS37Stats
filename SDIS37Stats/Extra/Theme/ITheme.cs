namespace SDIS37Stats.Extra.Theme
{
    using System.Drawing;

    public interface ITheme
    {
        #region Form
        Color Form_BackgroundColor();
        Color Form_FontColor();
        Color Form_BackgroundColorButton();
        Color Form_BackgroundColorTextbox();
        #endregion

        #region MainForm
        Color SettingsButton_DefaultBackgroundColor();
        Color SettingsButton_BackgroundColorWhenSelected();
        #endregion

        #region Graph
        Color Graph_BackgroundColor();
        Color Graph_BackgroundGraphColor();
        Color Graph_AxisColor();
        Color Graph_MainColor();
        #endregion

        #region OperationListView
        Color OperationListView_BackgroundColor();
        Color OperationListView_BackgroundColorList();
        Color OperationListView_BackgroundColorItem();
        Color OperationListView_FontColorItem();
        Color OperationListView_BackgroundColorHighlightItem();
        Color OperationListView_FontColorHighlightItem();
        #endregion

        #region SevenSegment
        Color SevenSegment_DarkColor();
        Color SevenSegment_LightColor();
        #endregion

        #region FirefighterAvailabilityListView
        Color FirefighterAvailabilityListView_BackgroundColor();
        Color FirefighterAvailabilityListView_BackgroundList();
        Color FirefighterAvailabilityListView_BackgroundColorItem();
        #endregion

        #region SettingsForm
        Color SettingsForm_ComboBox_BackgroundColor();
        Color SettingsForm_CheckBox_BackgroundColor();
        #endregion
    }
}
