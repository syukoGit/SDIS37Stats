// -----------------------------------------------------------------------
// <copyright file="Network.cs" company="SyukoTech">
// Copyright (c) SyukoTech. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------
namespace SDIS37Stats.Core.Syst
{
    using System;
    using System.Net.NetworkInformation;

    /// <summary>
    /// Static class for manages the network connection.
    /// </summary>
    public static class Network
    {
        /// <summary>
        /// Check if the software is connected to Internet.
        /// </summary>
        /// <param name="minimumSpeed">Defines the minimum speed of the connection.</param>
        /// <returns>Returns true if a network is available. Else returns false.</returns>
        public static bool IsNetworkAvailable(long minimumSpeed = 10000000)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
            {
                return false;
            }

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                if ((ni.OperationalStatus != OperationalStatus.Up)
                    || (ni.NetworkInterfaceType == NetworkInterfaceType.Loopback)
                    || (ni.NetworkInterfaceType == NetworkInterfaceType.Tunnel)
                    || ni.Speed < minimumSpeed
                    || ni.Description.Contains("virtual", StringComparison.OrdinalIgnoreCase)
                    || ni.Name.Contains("virtual", StringComparison.OrdinalIgnoreCase)
                    || ni.Description.Equals("Microsoft Loopback Adapter", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                return true;
            }

            return false;
        }
    }
}
