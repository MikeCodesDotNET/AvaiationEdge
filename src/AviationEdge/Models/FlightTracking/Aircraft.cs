using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationEdge.Models.FlightTracking
{
    public class Aircraft
    {
        [JsonProperty("iataCode")]
        public string IataCode { get; set; }

        [JsonProperty("icao24")]
        public string Icao24 { get; set; }

        [JsonProperty("icaoCode")]
        public string IcaoCode { get; set; }

        [JsonProperty("regNumber")]
        public string RegNumber { get; set; }
    }
}
