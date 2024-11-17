using System.Text.Json.Serialization;

namespace Bonds.Core.Response
{
    public class MoexBondsInfoResponse
    {
        [JsonPropertyName("description")]
        public DescriptionData Description { get; set; }
    }

    public class DescriptionData
    {
        [JsonPropertyName("columns")]
        public List<string> Columns { get; set; }

        [JsonPropertyName("data")]
        public List<List<object>> Data { get; set; }
    }
}
