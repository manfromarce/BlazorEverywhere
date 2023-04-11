using BlazorShared.Interfaces;

namespace MauiBlazorApp.InterfacesImpl
{
    public class  MauiHardware : IHardware
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
