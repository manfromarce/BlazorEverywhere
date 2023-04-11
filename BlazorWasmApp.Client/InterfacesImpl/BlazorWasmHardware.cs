namespace BlazorWasmApp.InterfacesImpl
{
    public class  BlazorWasmHardware : BlazorShared.Interfaces.IHardware
    {
        public bool IsBrowser => true;

        public async Task<string> GetOs()
        {
            return await Task.FromResult("Browser WASM");
        }

        public Task<string> GetManufacturer()
        {
            return Task.FromResult("-");
        }

        public Task<string> GetModel()
        {
            return Task.FromResult("-");
        }
    }
}
