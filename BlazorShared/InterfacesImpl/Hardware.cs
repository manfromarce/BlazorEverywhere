using Microsoft.JSInterop;

namespace BlazorShared.InterfacesImpl
{
    public class Hardware : BlazorShared.Interfaces.IHardware , IAsyncDisposable
    {
        
        private readonly Lazy<Task<IJSObjectReference>> moduleTask;
        public Hardware(IJSRuntime JSRuntime)
        {
            moduleTask = new(() => JSRuntime.InvokeAsync<IJSObjectReference>(
                "import", "./_content/BlazorShared/hardwareInfo.js").AsTask());
    //        moduleTask = new(() => JSRuntime.InvokeAsync<IJSObjectReference>(
    //"import", "./_content/BlazorShared/dist/.js").AsTask());
        }
       
        public bool IsBrowser => true;

        public async Task<string> GetOs()
        {
            try
            {
                var module = await moduleTask.Value;
                var ret = await module.InvokeAsync<string>("getOs");
                return ret;
             
            }
            catch(Exception ex)
            {
                var s = ex.ToString();
                return "Cannot detect";
            }
        }

        public Task<string> GetManufacturer()
        {
            return Task.FromResult("-");
        }

        public Task<string> GetModel()
        {
            return Task.FromResult("-");
        }

        public async ValueTask DisposeAsync()
        {
            if (moduleTask.IsValueCreated)
            {
                var module = await moduleTask.Value;
                await module.DisposeAsync();
            }
        }

    }
}
