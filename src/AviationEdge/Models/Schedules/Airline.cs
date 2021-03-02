using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationEdge.Models.Schedules
{
    public class Airline : CodesBaseModel
    {
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
