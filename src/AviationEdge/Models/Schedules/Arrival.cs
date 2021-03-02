using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationEdge.Models.Schedules
{
    public class Arrival : CodesBaseModel
    {
        [JsonProperty("actualRunway")]
        public DateTime ActualRunway { get; set; }

        [JsonProperty("actualTime")]
        public DateTime ActualTime { get; set; }

        [JsonProperty("baggage")]
        public string Baggage { get; set; }

        [JsonProperty("delay")]
        public int Delay { get; set; }

        [JsonProperty("estimatedRunway")]
        public DateTime EstimatedRunway { get; set; }

        [JsonProperty("estimatedTime")]
        public DateTime EstimatedTime { get; set; }

        [JsonProperty("gate")]
        public string Gate { get; set; }

        [JsonProperty("scheduledTime")]
        public DateTime ScheduledTime { get; set; }

        [JsonProperty("terminal")]
        public string Terminal { get; set; }
    }
}
