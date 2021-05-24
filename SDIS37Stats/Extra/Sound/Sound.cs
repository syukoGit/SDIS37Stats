// -----------------------------------------------------------------------
// <copyright file="Sound.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Extra.Sound
{
    using System;
    using System.Media;
    using System.Runtime.Versioning;

    /// <summary>
    /// Class for manages the sound of the software.
    /// </summary>
    public static class Sound
    {
        /// <summary>
        /// Represents a object that play the sounds.
        /// </summary>
        [SupportedOSPlatform("windows")]
        private static readonly SoundPlayer SoundPlayer = new ();

        /// <summary>
        /// Defines the type of sound to be played.
        /// </summary>
        public enum ESoundType
        {
            /// <summary>
            /// Play the notification sound for the new operation.
            /// </summary>
            NewOperationNotification,

            /// <summary>
            /// Play the notification sound for the new operation of the user's firehouse.
            /// </summary>
            NewOperationOfUserFirehouseNotification,
        }

        /// <summary>
        /// Gets or sets a value indicating whether the sound will be played.
        /// </summary>
        public static bool Mute { get; set; }

        /// <summary>
        /// Plays the sound for the windows os.
        /// </summary>
        /// <param name="soundType">A <see cref="ESoundType"/> that represents the sound to be played.</param>
        [SupportedOSPlatform("windows")]
        public static void PlaySoundOnlyWindows(ESoundType soundType)
        {
            if (!Sound.Mute)
            {
                switch (soundType)
                {
                    case ESoundType.NewOperationOfUserFirehouseNotification:
                        SoundPlayer.SoundLocation = @"Extra\Sound\StreetFireworksSound.wav";
                        break;
                    case ESoundType.NewOperationNotification:
                        SoundPlayer.SoundLocation = @"Extra\Sound\Confirmation-alert.wav";
                        break;
                    default:
                        Core.Syst.Log.WriteLog(Core.Syst.Log.EType.Error, "The sound type (" + soundType.ToString() + ") is not supported");
                        break;
                }

                try
                {
                    SoundPlayer.Play();
                }
                catch (Exception e)
                {
                    Core.Syst.Log.WriteLog(Core.Syst.Log.EType.Error, e.Message);
                }
            }
        }
    }
}
