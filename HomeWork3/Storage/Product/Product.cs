
namespace StorageApi.Product
{
    public class Product : IProduct
    {
        private readonly HttpClient _httpClient = new HttpClient();
        public async Task<bool> IsAvailable(int id)
        {
            using HttpResponseMessage response = await _httpClient.GetAsync($"https://localhost:44388/Product/GetProducts");
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            if (responseBody == "true")
            {
                return true;
            }

            if (responseBody == "false")
            {
                return false;
            }

            throw new Exception("Unknow response");
        }
    }
}