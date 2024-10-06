using System.Net.NetworkInformation;

namespace BlazorMac.Services
{
    public class NetworkService
    {
        public string GetMacAddress()
        {
            var macAddresses = NetworkInterface.GetAllNetworkInterfaces()
                .Where(nic => nic.NetworkInterfaceType != NetworkInterfaceType.Loopback 
                        && nic.OperationalStatus == OperationalStatus.Up)
                .Select(nic => nic.GetPhysicalAddress().ToString())
                .ToList();

            // Return the first MAC address found or a default message
            return macAddresses.FirstOrDefault() ?? "No MAC address found";
        }
    }
}