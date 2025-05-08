using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;

namespace Seccl.Api.Services
{
    public class SecclAuthService
    {
        private readonly HttpClient _httpClient;

        public SecclAuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> GetAccessTokenAsync()
        {
            var payload = new
            {
                firmId = "P1IMX",
                id = "nelahi6642@4tmail.net",
                password = "DemoBDM1"
            };

            var content = new StringContent(JsonSerializer.Serialize(payload), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync("https://pfolio-api-staging.seccl.tech/auth/token", content);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            using var doc = JsonDocument.Parse(json);
            return doc.RootElement.GetProperty("accessToken").GetString();
        }
    }
}
