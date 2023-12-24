using System.Text.Json.Serialization;

namespace Bonds.Core.Response
{
    public class MoexBondsQuotesResponse
    {
        [JsonPropertyName("securities")]
        public Securities Securities { get; set; }
    }

    public class Securities
    {
        [JsonPropertyName("columns")]
        public List<string> Columns { get; set; }

        [JsonPropertyName("data")]
        public List<List<object>> Data { get; set; }
    }
}
