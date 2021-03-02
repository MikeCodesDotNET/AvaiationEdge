using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationEdge.Models.FlightTracking
{
    public class FlightsResponse
    {
        [JsonProperty("aircraft")]
        public Aircraft Aircraft { get; set; }

        [JsonProperty("airline")]
        public Airline Airline { get; set; }

        [JsonProperty("arrival")]
        public Airline Arrival { get; set; }

        [JsonProperty("departure")]
        public Airline Departure { get; set; }

        [JsonProperty("flight")]
        public Flight Flight { get; set; }

        [JsonProperty("geography")]
        public Geography Geography { get; set; }

        [JsonProperty("speed")]
        public Speed Speed { get; set; }

        [JsonProperty("status")]
        public FlightTrackingStatus Status { get; set; }     
    }
}
