using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationEdge.Models.Schedules
{
    public class ScheduleResponse
    {
        [JsonProperty("airline")]
        public Airline Airline { get; set; }

        [JsonProperty("arrival")]
        public Arrival Arrival { get; set; }

        [JsonProperty("codeshared")]
        public Codeshared Codeshared { get; set; }

        [JsonProperty("departure")]
        public Departure Departure { get; set; }

        [JsonProperty("flight")]
        public Flight Flight { get; set; }

        [JsonProperty("status")]
        public ScheduleStatus Status { get; set; }

        [JsonProperty("type")]
        public ScheduleType Type { get; set; }
    }
}
