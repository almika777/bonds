using Bonds.Core.Response;
using Bonds.Core.Services.Interfaces;
using System.Text.Json;
using Bonds.Core.Helpers;

namespace Bonds.Core.Services
{
    public class BondsDataClient : IBondsDataClient
    {
        //https://iss.moex.com/iss/engines/stock/markets/bonds/boards/TQCB/securities 
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

        public async Task GetBondQuotes(string isin)
        {
            var client = _httpClientFactory.CreateClient("moex");
            var response = await client.GetAsync($"engines/stock/markets/bonds/boards/TQCB/securities/{isin}.json");

            var stringResponse = await response.Content.ReadAsStreamAsync();

        }

        public async Task<string> GetBondsQuotes()
        {
            var client = _httpClientFactory.CreateClient("moex");
            var response = await client.GetAsync($"engines/stock/markets/bonds/boards/TQCB/securities.json");

            var stringResponse = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(stringResponse);
            var c = MoexResponseDeserializer.Deserialize<BondsSecuritiesResponse>(data["securities"].ToString());
            return "stringResponse";
        }

        public async Task<string> GetDayResult()
        {
            var requestPath = "secstats";
            var client = _httpClientFactory.CreateClient("moex");
            var response = await client.GetAsync($"engines/stock/markets/bonds/{requestPath}.json");

            return await response.Content.ReadAsStringAsync();
        }
    }
}
