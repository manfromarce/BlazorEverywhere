using BlazorShared.Interfaces;
using Microsoft.Maui.Devices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Windows.Devices.Enumeration;
using Windows.Media.Miracast;
using Windows.System.Profile;

namespace WinUiBlazorApp.InterfacesImpl
{
    public class  WinUiHardware : IHardware
    {
        public bool IsBrowser => false;

        public async Task<string> GetOs()
        {
            return await Task.FromResult(DeviceInfo.Platform.ToString() + " " + DeviceInfo.VersionString);
        }

        public async Task<string> GetManufacturer()
        {
            return await Task.FromResult(DeviceInfo.Manufacturer);
        }

        public async Task<string> GetModel()
        {
            return await Task.FromResult(DeviceInfo.Model);
        }

    }
}
