﻿using System;
using System.Media;

namespace SDIS37Stats.Extra.Sound
{
    public static class Sound
    {
        private static readonly SoundPlayer soundPlayer = new SoundPlayer();

        public static void NewOperationNotification()
        {
            try
            {
                soundPlayer.SoundLocation = @"Extra\Sound\StreetFireworksSound.wav";
                soundPlayer.Play();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }
    }
}