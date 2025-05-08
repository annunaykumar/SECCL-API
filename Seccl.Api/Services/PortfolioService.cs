using Seccl.Middleware.Models;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Seccl.Api.Services
{
    public class PortfolioService
    {
        private readonly HttpClient _httpClient;
        private readonly SecclAuthService _authService;

        public PortfolioService(HttpClient httpClient, SecclAuthService authService)
        {
            _httpClient = httpClient;
            _authService = authService;
        }

        public async Task<List<PortfolioBalance>> GetPortfolioDataAsync()
        {
            var token = await _authService.GetAccessTokenAsync();
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var portfolioIds = new[] { "portfolio-id-1", "portfolio-id-2", "portfolio-id-3" }; // Replace with actual IDs
            var allBalances = new List<PortfolioBalance>();

            foreach (var id in portfolioIds)
            {
                var response = await _httpClient.GetAsync($"https://pfolio-api-staging.seccl.tech/v1/portfolios/{id}/balances");
                var content = await response.Content.ReadAsStringAsync();

                // Deserialization depends on actual JSON structure
                var balances = JsonSerializer.Deserialize<List<PortfolioBalance>>(content);
                if (balances != null)
                    allBalances.AddRange(balances);
            }

            return allBalances;
        }
    }
}
