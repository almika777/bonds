using Bonds.Core.Helpers;
using Bonds.Core.Response;
using Bonds.Core.Services.Interfaces;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace Bonds.Core.Services
{
    public class MoexHttpDataClient : IMoexHttpDataClient
    {
        private readonly HttpClient _client;

        public MoexHttpDataClient(IHttpClientFactory httpClientFactory)
        {
            _client = httpClientFactory.CreateClient("moex");
        }

        public async Task<BondsExtendedMarketdataResponse> GetBondExtendedData(string isin)
        {
            string? GetSecondValueFromStringArray(string? s) 
                => s == null ? null : JsonSerializer.Deserialize<JsonArray>(s)?[2]?.ToString();

            var response = await _client.GetAsync($"securities/{isin}.json");
            var stringResponse = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<Dictionary<string, Dictionary<string, object>>>(stringResponse);
            var rows = JsonSerializer.Deserialize<JsonElement>(data["description"]["data"].ToString()!).EnumerateArray()
                    .Select(z => z.ToString())
                    .ToList();

            var emitterRow = rows.FirstOrDefault(x => x.Contains("emitter_id", StringComparison.InvariantCultureIgnoreCase));
            var nameRow = rows.FirstOrDefault(x => x.Contains("name", StringComparison.InvariantCultureIgnoreCase));
            var shortNameRow = rows.FirstOrDefault(x => x.Contains("shortname", StringComparison.InvariantCultureIgnoreCase));

            var shortName = GetSecondValueFromStringArray(shortNameRow);
            var name = GetSecondValueFromStringArray(nameRow);
            var emitter = GetSecondValueFromStringArray(emitterRow);

            return new BondsExtendedMarketdataResponse
            {
                ISIN = isin,
                ShortName = shortName,
                Name = name,
                EmitterId = long.TryParse(emitter, out var emitterId) 
                    ? emitterId 
                    : null,
            };
        }

        // список всех облигаций на мосбирже
        public async Task<List<BondsSecuritiesResponse>> GetAllBonds()
        {
            var response = await _client.GetAsync($"engines/stock/markets/bonds/securities.json");

            var stringResponse = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(stringResponse);
            return MoexResponseDeserializer.DeserializeList<BondsSecuritiesResponse>(data["securities"].ToString());
        }

        // список всех облигаций на мосбирже XS0114288789
        public async Task<List<BondsMarketdataResponse>> GetAllBondsMarketdata()
        {
            var response = await _client.GetAsync($"engines/stock/markets/bonds/securities.json?marketprice_board=1");

            var stringResponse = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(stringResponse);
            return MoexResponseDeserializer.DeserializeList<BondsMarketdataResponse>(data["marketdata"].ToString());
        }          
        
        // список всех облигаций на мосбирже XS0114288789
        public async Task<(List<BondsMarketdataResponse>, List<BondsSecuritiesResponse>)> GetAllBondsMarketdataAndSecurity()
        {
            var response = await _client.GetAsync($"engines/stock/markets/bonds/securities.json?marketprice_board=1");

            var stringResponse = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(stringResponse);
            return (MoexResponseDeserializer.DeserializeList<BondsMarketdataResponse>(data["marketdata"].ToString()),
                MoexResponseDeserializer.DeserializeList<BondsSecuritiesResponse>(data["securities"].ToString()));
        }        
        
        public async Task<List<BondsSecuritiesResponse>> GetAllBondsSecurities()
        {
            var response = await _client.GetAsync($"engines/stock/markets/bonds/securities.json?marketprice_board=1");

            var stringResponse = await response.Content.ReadAsStreamAsync();
            var data = await JsonSerializer.DeserializeAsync<Dictionary<string, object>>(stringResponse);
            return MoexResponseDeserializer.DeserializeList<BondsSecuritiesResponse>(data["securities"].ToString());
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
