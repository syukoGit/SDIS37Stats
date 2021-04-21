namespace SDIS37Stats.Core.Syst
{
    using System;
    using System.Net.NetworkInformation;

    public static class Network
    {
        public static bool IsNetworkAvailable(long minimumSpeed = 10000000)
        {
            if (!NetworkInterface.GetIsNetworkAvailable())
                return false;

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
