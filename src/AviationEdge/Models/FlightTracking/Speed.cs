using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationEdge.Models.FlightTracking
{
    public class Speed
    {
        [JsonProperty("horizontal")]
        public double Horizontal { get; set; }

        [JsonProperty("isGround")]
        public long IsGround { get; set; }

        [JsonProperty("vspeed")]
        public double Vspeed { get; set; }
    }
}
