namespace StorageApi.Product
{
    public interface IProduct
    {
        public Task<bool> IsAvailable(int id);
    }
}