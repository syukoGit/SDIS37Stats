// -----------------------------------------------------------------------
// <copyright file="Setting.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Core.Syst
{
    using System;
    using System.ComponentModel;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using SDIS37Stats.Extra.Theme;

    /// <summary>
    /// Class for manages the software's settings.
    /// </summary>
    public class Setting : INotifyPropertyChanged
    {
        /// <summary>
        /// Contains the current <see cref="ITheme"/> used by software.
        /// </summary>
        private ITheme theme = new LightTheme();

        /// <summary>
        /// Contains if the sound is activate or disable.
        /// </summary>
        private bool muteSound = false;

        /// <summary>
        /// Contains the number of operations of the department to be displayed.
        /// </summary>
        private int nbOperationOfDepartmentDisplayed = 15;

        /// <summary>
        /// Contains the number of operations of the user's firehouse to be displayed.
        /// </summary>
        private int nbOperationOfUserFirehouseDisplayed = 5;

        /// <summary>
        /// Contains the number of firefighters' availabilities to be displayed.
        /// </summary>
        private int nbFirefighterAvailabilityDisplayed = 100;

        /// <summary>
        /// Represents the method that will handle the <see cref="ThemeUpdated"/> event of the <see cref="Setting"/> class.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">An object that contains no event data.</param>
        public delegate void ThemeUpdatedEventHandler(object sender, EventArgs e);

        /// <summary>
        /// Occurs when a property of the <see cref="Setting"/> class is changed.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when the theme is updated.
        /// </summary>
        public event ThemeUpdatedEventHandler ThemeUpdated;

        /// <summary>
        /// Gets the current settings used by the software.
        /// </summary>
        public static Setting CurrentSetting { get; } = new ();

        /// <summary>
        /// Gets or sets the current <see cref="ITheme"/> used by the software.
        /// </summary>
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
                    this.ThemeUpdated(this, EventArgs.Empty);
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the sound is activate or disable.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the number of operations of the department to be displayed.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the number of operations of the user's firehouse to be displayed.
        /// </summary>
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

        /// <summary>
        /// Gets or sets the number of firefighters' availabilities to be displayed.
        /// </summary>
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

        /// <summary>
        /// Updates the settings with a other <see cref="Setting"/> instance.
        /// </summary>
        /// <param name="newSetting">A <see cref="Setting"/> to be used.</param>
        public static void UpdateSettings(Setting newSetting)
        {
            foreach (var property in typeof(Setting).GetProperties(BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public))
            {
                property.SetValue(CurrentSetting, property.GetValue(newSetting));
            }
        }

        /// <summary>
        /// Creates a deep copy of the settings.
        /// </summary>
        /// <returns>A deep copy of the settings.</returns>
        public Setting DeepCopy()
        {
            var copy = (Setting)this.MemberwiseClone();

            copy.MuteSound = this.MuteSound;
            copy.Theme = this.Theme;

            return copy;
        }

        /// <summary>
        /// Called for invoke a <see cref="PropertyChanged"/> event.
        /// </summary>
        /// <param name="propertyName">The property's name that called the function.</param>
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
