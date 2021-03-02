using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace AviationEdge.Models.Routes
{
    public class Route
    {
        [JsonProperty("airlineIata")]
        public string AirlineIata { get; set; }

        [JsonProperty("airlineIcao")]
        public string AirlineIcao { get; set; }

        [JsonProperty("arrivalIata")]
        public string ArrivalIata { get; set; }

        [JsonProperty("arrivalIcao")]
        public string ArrivalIcao { get; set; }

        [JsonProperty("arrivalTerminal")]
        public string ArrivalTerminal { get; set; }

        [JsonProperty("arrivalTime")]
        public DateTimeOffset ArrivalTime { get; set; }

        [JsonProperty("codeshares")]
        public List<Codeshare> Codeshares { get; set; }

        [JsonProperty("departureIata")]
        public string DepartureIata { get; set; }

        [JsonProperty("departureIcao")]
        public string DepartureIcao { get; set; }

        [JsonProperty("departureTerminal")]
        public string? DepartureTerminal { get; set; }

        [JsonProperty("departureTime")]
        public DateTimeOffset DepartureTime { get; set; }

        [JsonProperty("flightNumber")]
        public string FlightNumber { get; set; }


        [JsonProperty("regNumber")]
        public List<string> RegNumber { get; set; }
    }
}
