namespace SDIS37Stats.Core.Syst
{
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Reflection;
    using Extra.Theme;

    public class Setting : INotifyPropertyChanged
    {
        private static readonly Setting currentSetting = new();

        private ITheme theme = new LightTheme();
        private bool muteSound = false;
        private int nbOperationOfDepartmentDisplayed = 15;
        private int nbOperationOfUserFirehouseDisplayed = 5;
        private int nbFirefighterAvailabilityDisplayed = 100;

        public event PropertyChangedEventHandler PropertyChanged;

        public static Setting CurrentSetting => currentSetting;

        public ITheme Theme
        {
            get
            {
                return this.theme;
            }
            set
            {
                if (this.theme.ThemeType != value.ThemeType)
                {
                    this.theme = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public bool MuteSound
        {
            get
            {
                return this.muteSound;
            }
            set
            {
                if (this.muteSound != value)
                {
                    this.muteSound = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public int NbOperationOfDepartmentDisplayed
        {
            get
            {
                return this.nbOperationOfDepartmentDisplayed;
            }
            set
            {
                if (this.nbOperationOfDepartmentDisplayed != value)
                {
                    this.nbOperationOfDepartmentDisplayed = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public int NbOperationOfUserFirehouseDisplayed
        {
            get
            {
                return this.nbOperationOfUserFirehouseDisplayed;
            }
            set
            {
                if (this.nbOperationOfUserFirehouseDisplayed != value)
                {
                    this.nbOperationOfUserFirehouseDisplayed = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public int NbFirefighterAvailabilityDisplayed
        {
            get
            {
                return this.nbFirefighterAvailabilityDisplayed;
            }
            set
            {
                if (this.nbFirefighterAvailabilityDisplayed != value)
                {
                    this.nbFirefighterAvailabilityDisplayed = value;
                    this.NotifyPropertyChanged();
                }
            }
        }

        public static void UpdateSettings(Setting newSetting)
        {
            foreach (var property in typeof(Setting).GetProperties(BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public))
            {
                property.SetValue(CurrentSetting, property.GetValue(newSetting));
            }
        }

        public Setting DeepCopy()
        {
            var copy = (Setting)this.MemberwiseClone();

            copy.MuteSound = this.MuteSound;
            copy.Theme = this.Theme;

            return copy;
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
