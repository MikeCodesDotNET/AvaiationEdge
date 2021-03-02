using AviationEdge.Converters;
using Newtonsoft.Json;

namespace AviationEdge.Models.Nearby
{
    public class NearbyResponse
    {
        [JsonProperty("GMT")]
        [JsonConverter(typeof(StringToDoubleConverter))]
        public long Gmt { get; set; }

        [JsonProperty("codeIataAirport")]
        public string CodeIataAirport { get; set; }

        [JsonProperty("codeIataCity")]
        public string CodeIataCity { get; set; }

        [JsonProperty("codeIcaoAirport")]
        public string CodeIcaoAirport { get; set; }

        [JsonProperty("codeIso2Country")]
        public string CodeIso2Country { get; set; }

        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("latitudeAirport")]
        public double LatitudeAirport { get; set; }

        [JsonProperty("longitudeAirport")]
        public double LongitudeAirport { get; set; }

        [JsonProperty("nameAirport")]
        public string NameAirport { get; set; }

        [JsonProperty("nameCountry")]
        public string NameCountry { get; set; }

        [JsonProperty("phone")]
        public string Phone { get; set; }

        [JsonProperty("timezone")]
        public string Timezone { get; set; }
    }
}
