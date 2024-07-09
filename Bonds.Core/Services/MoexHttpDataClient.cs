using Bonds.Core.Helpers;
using Bonds.Core.Response;
using Bonds.Core.Services.Interfaces;
using System.Text.Json;

namespace Bonds.Core.Services
{
    public class MoexHttpDataClient : IMoexHttpDataClient
    {
        private readonly HttpClient _client;

        public MoexHttpDataClient(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("moex");
        }

        public async Task<MoexBondsInfoResponse?> GetBondsInfo(string isin)
        {
            var response = await _client.GetAsync($"securities/{isin}.json");
            var stringResponse = await response.Content.ReadAsStreamAsync();

            return await JsonSerializer.DeserializeAsync<MoexBondsInfoResponse>(stringResponse);
        }

        // список всех облигаций на мосбирже
        public async Task<List<BondsSecuritiesResponse>> GetAllBonds()
        {
            var response = await _client.GetAsync($"engines/stock/markets/bonds/securities.json");

            var stringResponse = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(stringResponse);
            return MoexResponseDeserializer.DeserializeList<BondsSecuritiesResponse>(data["securities"].ToString());
        }
        
        // список всех облигаций на мосбирже
        public async Task<List<BondsMarketdataResponse>> GetAllBondsMarketdata()
        {
            var response = await _client.GetAsync($"engines/stock/markets/bonds/securities.json");

            var stringResponse = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(stringResponse);
            return MoexResponseDeserializer.DeserializeList<BondsMarketdataResponse>(data["marketdata"].ToString());
        }

        //https://iss.moex.com/iss/engines/stock/markets/bonds/securities/{ISIN}/trades
        //сделки по инструменту за сегодня
        public async Task<List<BondsTradeResponse>> GetBondsTrades(string isin)
        {
            Dictionary<string, object>? data;

            using var response = await _client.GetAsync($"engines/stock/markets/bonds/securities/{isin}/trades.json");
            await using (var stringResponse = await response.Content.ReadAsStreamAsync())
            {
                data = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(stringResponse);
            }
            return MoexResponseDeserializer.DeserializeList<BondsTradeResponse>(data["trades"].ToString());
        }

    }
}
