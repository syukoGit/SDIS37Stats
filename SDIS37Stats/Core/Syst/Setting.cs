using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIS37Stats.Core.Syst
{
    public class Setting
    {
        public enum THEMETYPE
        {
            Dark,
            Light
        }

        public THEMETYPE ThemeType { get; set; } = THEMETYPE.Light;

        public Extra.Theme.ITheme Theme { get; set; } = new Extra.Theme.DarkTheme();

        public bool MuteSound { get; set; } = false;

        public Setting DeepCopy()
        {
            var copy = (Setting)this.MemberwiseClone();

            copy.ThemeType = this.ThemeType;
            copy.MuteSound = this.MuteSound;
            copy.Theme = this.Theme;

            return copy;
        }
    }
}
