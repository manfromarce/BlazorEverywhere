using System.Runtime.InteropServices;
using BlazorShared.Interfaces;

namespace PhotinoBlazorApp.InterfacesImpl
{
    public class  PhotinoHardware : IHardware
    {
        public bool IsBrowser => false;

        public async Task<string> GetOs()
        {
            return await Task.FromResult(RuntimeInformation.OSDescription);
        }

        public async Task<string> GetManufacturer()
        {
            return await Task.FromResult("-");
        }

        public async Task<string> GetModel()
        {
            return await Task.FromResult("-");
        }
    }
}
