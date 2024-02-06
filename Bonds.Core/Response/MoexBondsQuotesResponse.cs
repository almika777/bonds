using System.Text.Json.Serialization;

namespace Bonds.Core.Response
{

    public class MoexResponseObject
    {
        [JsonPropertyName("metadata")]
        public List<string> Metadata { get; set; }  
        
        [JsonPropertyName("columns")]
        public List<string> Columns { get; set; }

        [JsonPropertyName("data")]
        public List<List<object>> Data { get; set; }
    }
}
