using BlazorShared.Interfaces;
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
            return RuntimeInformation.OSDescription;
        }

        public async Task<string> GetManufacturer()
        {
            return "-";
        }

        public async Task<string> GetModel()
        {
            return "-";
        }

    }
}
