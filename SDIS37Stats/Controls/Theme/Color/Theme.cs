using System.Drawing;

namespace SDIS37Stats.Controls.Theme
{
    public abstract class MyColor
    {
        protected static readonly Color dark1 = Color.FromArgb(64, 64, 64); //Background
        protected static readonly Color dark2 = Color.FromArgb(75, 75, 75);

        protected static readonly Color white1 = Color.FromArgb(240, 240, 240); // FontColor

        protected static readonly Color yellow1 = Color.FromArgb(220, 220, 0);

        protected static readonly Color debugColor = Color.Green;
    }

    public abstract class Default : MyColor
    {
        public static Color BackgroundColor => dark1;
        public static Color FontColor => white1;
        public static Color DebugColor => debugColor;
    }

    public abstract class Graph : MyColor
    {
        public static Color BackgroundColor => dark2;
        public static Color AxisColor => yellow1;
        public static Color MainBarColor => white1;
    }
}
