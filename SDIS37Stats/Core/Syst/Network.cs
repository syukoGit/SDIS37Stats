namespace SDIS37Stats.Core.Syst
{
    using System.Windows.Forms;

    public static class Network
    {
        public static bool IsNetworkConnected()
        {
            return SystemInformation.Network;
        }
    }
}
