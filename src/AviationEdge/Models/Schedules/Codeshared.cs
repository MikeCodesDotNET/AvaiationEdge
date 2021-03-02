using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationEdge.Models.Schedules
{
    public class Codeshared
    {
        [JsonProperty("airline")]
        public Airline Airline { get; set; }

        [JsonProperty("flight")]
        public Flight Flight { get; set; }
    }
}
