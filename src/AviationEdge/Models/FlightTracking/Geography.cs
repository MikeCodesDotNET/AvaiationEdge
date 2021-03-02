using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationEdge.Models.FlightTracking
{
    public class Geography
    {
        [JsonProperty("altitude")]
        public double Altitude { get; set; }

        [JsonProperty("direction")]
        public double Direction { get; set; }

        [JsonProperty("latitude")]
        public double Latitude { get; set; }

        [JsonProperty("longitude")]
        public double Longitude { get; set; }
    }
}
