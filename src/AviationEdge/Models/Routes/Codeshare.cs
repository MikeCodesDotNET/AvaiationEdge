using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AviationEdge.Models.Routes
{
    public class Codeshare
    {
        [JsonProperty("airline_code")]
        public string AirlineCode { get; set; }

        [JsonProperty("flight_number")]        
        public string FlightNumber { get; set; }
    }
}
