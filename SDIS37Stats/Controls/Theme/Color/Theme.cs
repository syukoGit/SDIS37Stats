using System.Drawing;

namespace SDIS37Stats.Controls.Theme
{
    public abstract class MyColor
    {
        protected static readonly Color gray7 = Color.FromArgb(64, 64, 64); //Background
        protected static readonly Color gray6 = Color.FromArgb(75, 75, 75);
        protected static readonly Color gray5 = Color.FromArgb(100, 100, 100);

        protected static readonly Color white1 = Color.FromArgb(240, 240, 240); // FontColor

        protected static readonly Color yellow1 = Color.FromArgb(220, 220, 0);
        protected static readonly Color yellow2 = Color.FromArgb(255, 255, 180);

        protected static readonly Color debugColor = Color.Green;
    }

    public abstract class Default : MyColor
    {
        public static Color BackgroundColor => gray7;
        public static Color FontColor => white1;
        public static Color DebugColor => debugColor;
    }

    public abstract class Graph : MyColor
    {
        public static Color BackgroundColor => gray6;
        public static Color AxisColor => yellow1;
        public static Color MainBarColor => white1;
    }

    public abstract class RecentOperationList : MyColor
    {
        public static Color BackgroundList => gray6;
        public static Color BackgroundColorItem => gray5;
        public static Color FontColorItem => Default.FontColor;
        public static Color BackgroundColorHighlightItem => yellow2;
        public static Color FontColorHighlightItem => gray7;
    }

    public abstract class GetCredential : MyColor
    {
        public static Color BackgroundColorButton => gray6;
        public static Color BackgroundColorTextbox => gray6;
    }
}
