using System.Text.Json;
using Bonds.Core.Response;
using Bonds.Core.Services.Interfaces;

namespace Bonds.Core.Services
{
    public class BondsDataClient : IBondsDataClient
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BondsDataClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<MoexBondsInfoResponse> GetBondsInfo(string isin)
        {
            var client = _httpClientFactory.CreateClient("moex");
            var response = await client.GetAsync($"securities/{isin}.json");

            var stringResponse = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<MoexBondsInfoResponse>(stringResponse);
        }

        public async Task<MoexBondsQuotesResponse> GetBondsQuotes(string isin)
        {
            var client = _httpClientFactory.CreateClient("moex");
            var response = await client.GetAsync($"engines/stock/markets/bonds/boards/TQCB/securities/{isin}.json");

            var stringResponse = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<MoexBondsQuotesResponse>(stringResponse);
        }
    }
}
