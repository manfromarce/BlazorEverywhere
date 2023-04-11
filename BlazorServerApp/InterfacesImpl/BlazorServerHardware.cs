using BlazorShared.Interfaces;
using System.Runtime.InteropServices;

namespace BlazorServerApp.InterfacesImpl
{
    public class  BlazorServerHardware : IHardware
    {
        public bool IsBrowser => true;

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
