namespace BlazorShared.Interfaces
{
    public interface IHardware
    {
        public bool IsBrowser { get; }

        public async Task<string> GetOs()
        {
            return await Task.FromResult("Not Implemented");
        }

        public async Task<string> GetManufacturer()
        {
            return await Task.FromResult("Not Implemented");
        }

        public async Task<string> GetModel()
        {
            return await Task.FromResult("Not Implemented");
        }
    }
}
