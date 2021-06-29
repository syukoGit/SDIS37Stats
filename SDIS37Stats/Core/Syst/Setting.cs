// -----------------------------------------------------------------------
// <copyright file="Setting.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Core.Syst
{
    using System;
    using System.ComponentModel;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.Serialization;
    using SDIS37Stats.Extra.Theme;

    /// <summary>
    /// Class for manages the software's settings.
    /// </summary>
    [Serializable]
    public class Setting : INotifyPropertyChanged, IXmlSerializable
    {
        /// <summary>
        /// Path where the settings are saved.
        /// </summary>
        private static readonly string SettingsFolderForSave = @"Settings\";

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
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Occurs when the theme is updated.
        /// </summary>
        [field: NonSerialized]
        public event ThemeUpdatedEventHandler ThemeUpdated;

        /// <summary>
        /// Gets the current settings used by the software.
        /// </summary>
        [XmlIgnore]
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
                    this.ThemeUpdated?.Invoke(this, EventArgs.Empty);
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
        /// Export a <see cref="Setting"/> instance in a xml file.
        /// </summary>
        /// <param name="settings">A <see cref="Setting"/> instance to be export.</param>
        /// <param name="fileName">A file's name where the operations list will be write.</param>
        public static void ExportSettingsToXml(Setting settings, string fileName)
        {
            if (!Directory.Exists(SettingsFolderForSave))
            {
                _ = Directory.CreateDirectory(SettingsFolderForSave);
            }

            XmlSerializer xmlSerializer = new (typeof(Setting));

            using (StreamWriter writer = new (SettingsFolderForSave + fileName))
            {
                xmlSerializer.Serialize(writer, settings);
                writer.Close();
            }
        }

        /// <summary>
        /// Import a <see cref="Setting"/> instance contained in a xml file.
        /// </summary>
        /// <param name="filepath">A file path of the xml file.</param>
        public static void ImportSettings(string filepath)
        {
            if (!File.Exists(filepath))
            {
                return;
            }

            XmlSerializer xmlSerializer = new (typeof(Setting));

            using (StreamReader reader = new (filepath))
            {
                UpdateSettings((Setting)xmlSerializer.Deserialize(reader));
                reader.Close();
            }
        }

        /// <summary>
        /// Creates a deep copy of the settings.
        /// </summary>
        /// <returns>A deep copy of the settings.</returns>
        public Setting DeepCopy()
        {
            var copy = new Setting();

            foreach (PropertyInfo property in typeof(Setting).GetProperties(BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public))
            {
                property.SetValue(copy, property.GetValue(this));
            }

            return copy;
        }

        /// <inheritdoc/>
        public XmlSchema GetSchema() => null;

        /// <inheritdoc/>
        public void ReadXml(XmlReader reader)
        {
            try
            {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.Name == "Theme")
                        {
                            var type = (ITheme.EThemeType)Enum.Parse(typeof(ITheme.EThemeType), reader.GetAttribute("Type"));

                            this.theme = type switch
                            {
                                ITheme.EThemeType.Light => new LightTheme(),
                                ITheme.EThemeType.Dark => new DarkTheme(),
                                _ => new DarkTheme(),
                            };

                            this.theme.ReadXml(reader);
                        }
                        else
                        {
                            var prop = this.GetType().GetProperty(reader.Name);
                            string value = reader.GetAttribute("Value");
                            if (!string.IsNullOrEmpty(value))
                            {
                                if (prop.PropertyType.FullName == "System.Boolean")
                                {
                                    prop.SetValue(this, bool.Parse(value));
                                }
                                else if (prop.PropertyType.FullName == "System.Int32")
                                {
                                    prop.SetValue(this, int.Parse(value));
                                }
                                else
                                {
                                    prop.SetValue(this, value);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(Log.EType.Error, "Read XML settings:" + ex.Message + "\n" + ex.StackTrace);
            }
        }

        /// <inheritdoc/>
        public void WriteXml(XmlWriter writer)
        {
            foreach (var prop in this.GetType().GetProperties(BindingFlags.SetProperty | BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty))
            {
                if (prop.PropertyType.IsAssignableFrom(typeof(ITheme)))
                {
                    var theme = (ITheme)prop.GetValue(this);

                    writer.WriteStartElement(prop.Name);
                    theme.WriteXml(writer);
                    writer.WriteEndElement();
                }
                else
                {
                    writer.WriteStartElement(prop.Name);
                    writer.WriteAttributeString("Value", prop.GetValue(this).ToString());
                    writer.WriteEndElement();
                }
            }
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
