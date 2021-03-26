using System;
using System.Media;
using System.Runtime.Versioning;

namespace SDIS37Stats.Extra.Sound
{
    public static class Sound
    {
        public enum SoundType
        {
            NewOperationNotification,
            NewOperationOfUserFirehouseNotification
        }

        [SupportedOSPlatform("windows")]
        private static readonly SoundPlayer soundPlayer = new();

        public static bool Mute { get; set; }

        [SupportedOSPlatform("windows")]
        public static void PlaySoundOnlyWindows(SoundType soundType)
        {
            if (!Sound.Mute)
            {
                switch (soundType)
                {
                    case SoundType.NewOperationOfUserFirehouseNotification:
                        soundPlayer.SoundLocation = @"Extra\Sound\StreetFireworksSound.wav";
                        break;
                    case SoundType.NewOperationNotification:
                        soundPlayer.SoundLocation = @"Extra\Sound\Confirmation-alert.wav";
                        break;
                    default:
                        Core.Syst.Log.WriteLog(Core.Syst.Log.TYPE.Error, "The sound type (" + soundType.ToString() + ") is not supported");
                        break;
                }

                try
                {
                    soundPlayer.Play();
                }
                catch (Exception e)
                {
                    Core.Syst.Log.WriteLog(Core.Syst.Log.TYPE.Error, e.Message);
                }
            }

        }
    }
}
