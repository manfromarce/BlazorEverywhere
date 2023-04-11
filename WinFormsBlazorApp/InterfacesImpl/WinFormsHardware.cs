using BlazorShared.Interfaces;
using Microsoft.Win32;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace WinFormsBlazorApp.InterfacesImpl
{
    public class  WinFormsHardware : IHardware
    {
        public bool IsBrowser => false;

        public async Task<string> GetOs()
        {
            return await Task.FromResult(RuntimeInformation.OSDescription);
        }

        public async Task<string> GetManufacturer()
        {
            var keyValue = "SYSTEM\\CurrentControlSet\\Control\\SystemInformation";
            var regKey = Registry.LocalMachine.OpenSubKey(keyValue, false);
            if(regKey != null)
            {
                return await Task.FromResult((string)regKey.GetValue("SystemManufacturer", "-"));
            }
            return "-";
        }

        public async Task<string> GetModel()
        {
            var keyValue = "SYSTEM\\CurrentControlSet\\Control\\SystemInformation";
            var regKey = Registry.LocalMachine.OpenSubKey(keyValue, false);
            if (regKey != null)
            {
                return await Task.FromResult((string)regKey.GetValue("SystemProductName", "-"));
            }
            return "-";
        }
    }
}
