using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SDIS37Stats.Core.Syst
{
    public class Setting
    {
        public enum ThemeMode
        {
            Dark,
            Light
        }

        public Extra.Theme.ITheme Theme { get; set; } = new Extra.Theme.LightTheme();

        public bool MuteSound { get; set; } = false;
    }
}
