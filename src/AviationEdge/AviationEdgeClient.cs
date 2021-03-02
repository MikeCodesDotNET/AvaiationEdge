using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using AviationEdge.Models;
using AviationEdge.Models.FlightTracking;
using AviationEdge.Models.Schedules;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace AviationEdge
{
    public class AviationEdgeClient
    {
        string _endPointRoot = "https://aviation-edge.com/v2/public";
        string _apiKey;

        public AviationEdgeClient(string apiKey)
        {
            _apiKey = apiKey;
            FlightTrackerClient = new FlightTrackerClient(_endPointRoot, _apiKey);
            SchedulesClient = new SchedulesClient(_endPointRoot, _apiKey);
        }

        public FlightTrackerClient FlightTrackerClient { get; private set; }

        public SchedulesClient SchedulesClient { get; private set; }
    }








    public class AirCode
    {
        public string Code { get; private set; }

        public CodeType CodeType { get; private set; }

        public AirCode(string code, CodeType type)
        {
            Code = code;
            CodeType = type;
        }
    }

    public enum CodeType
    {
        IATA,
        ICAO
    }


    public enum Endpoints
    {
        flights,
        timetable,
        routes,
        nearby,
        autocomplete,
        flightsHistory,
    }
}
