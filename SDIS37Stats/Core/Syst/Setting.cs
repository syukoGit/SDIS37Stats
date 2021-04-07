namespace SDIS37Stats.Core.Syst
{
    public class Setting
    {

        public static Setting CurrentSetting { get; set; } = new();

        public Extra.Theme.ITheme Theme { get; set; } = new Extra.Theme.LightTheme();

        public bool MuteSound { get; set; } = false;

        public int NbOperationOfDepartmentDisplayed { get; set; } = 15;

        public int NbOperationOfUserFirehouseDisplayed { get; set; } = 5;

        public int NbFirefighterAvailabilityDisplayed { get; set; } = 100;

        public Setting DeepCopy()
        {
            var copy = (Setting)this.MemberwiseClone();

            copy.MuteSound = this.MuteSound;
            copy.Theme = this.Theme;

            return copy;
        }
    }
}
