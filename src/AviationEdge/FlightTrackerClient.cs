using AviationEdge.Models.FlightTracking;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace AviationEdge
{
    public class FlightTrackerClient
    {
        private AirCode departureAirport;
        private AirCode arrivalAirport;
        private string aircraftRegistration;
        private AirCode airline;
        private AirCode flightCode;
        private string flightNumber;
        private FlightTrackingStatus status;
        private int limit;
        private RangeQuery range;


        private string _apiKey;
        private string _endpoint;

        internal FlightTrackerClient(string endpoint, string apiKey)
        {
            _endpoint = endpoint;
            _apiKey = apiKey;
        }

        Dictionary<string, object> queryParams = new Dictionary<string, object>();



        public FlightTrackerClient()
        {
            limit = 100;
        }

        public FlightTrackerClient DepartureAirport(string code, CodeType codeType)
        {
            departureAirport = new AirCode(code, codeType);
            if (codeType == CodeType.IATA)
            {
                queryParams.Add("depIata", code);
            }
            if (codeType == CodeType.ICAO)
            {
                queryParams.Add("depIcao", code);
            }
            return this;
        }

        public FlightTrackerClient ArrivalAirport(string code, CodeType codeType)
        {
            arrivalAirport = new AirCode(code, codeType);
            if (codeType == CodeType.IATA)
            {
                queryParams.Add("arrIata", code);
            }
            if (codeType == CodeType.ICAO)
            {
                queryParams.Add("arrIcao", code);
            }
            return this;
        }

        public FlightTrackerClient Aircraft(string registration)
        {
            aircraftRegistration = registration;
            queryParams.Add("regNum", registration);
            return this;
        }

        public FlightTrackerClient Flight(string code, CodeType codeType)
        {
            flightCode = new AirCode(code, codeType);
            if (codeType == CodeType.IATA)
            {
                queryParams.Add("flightIata", code);
            }
            if (codeType == CodeType.ICAO)
            {
                queryParams.Add("flightIcao", code);
            }
            return this;
        }

        public FlightTrackerClient Flight(string flightNumber)
        {
            this.flightNumber = flightNumber;
            queryParams.Add("flightNum", flightNumber);
            return this;
        }

        public FlightTrackerClient Status(FlightTrackingStatus status)
        {
            this.status = status;
            switch (status)
            {
                case FlightTrackingStatus.EnRoute:
                    queryParams.Add("status", "en-route");
                    break;
                case FlightTrackingStatus.Started:
                    queryParams.Add("status", "started");
                    break;
                case FlightTrackingStatus.Landed:
                    queryParams.Add("status", "landed");
                    break;
                case FlightTrackingStatus.Unknown:
                    queryParams.Add("status", "unknown");
                    break;

            }
            return this;
        }

        public FlightTrackerClient Limit(int limit = 100)
        {
            this.limit = limit;
            queryParams.Add("limit", limit);
            return this;
        }

        public FlightTrackerClient InRangeOf(double lat, double lng, int distnaceInKM)
        {
            range = new RangeQuery(lat, lng, distnaceInKM);
            queryParams.Add("lat", lat);
            queryParams.Add("lng", lng);
            queryParams.Add("distance", distnaceInKM);
            return this;
        }

        public FlightTrackerClient Airline(string code, CodeType codeType)
        {
            airline = new AirCode(code, codeType);
            if (codeType == CodeType.IATA)
            {
                queryParams.Add("airlineIata", code);
            }
            if (codeType == CodeType.ICAO)
            {
                queryParams.Add("airlineIcao", code);
            }
            return this;
        }

        public async Task<IEnumerable<FlightsResponse>> Query(CancellationToken ct)
        {
            var jsonResult = await _endpoint
                            .AppendPathSegment("flights")
                            .SetQueryParam("key", _apiKey)
                            .SetQueryParams(queryParams)
                            .GetStringAsync(ct);

            return JsonConvert.DeserializeObject<List<FlightsResponse>>(jsonResult, jsonConverterSettings);
        }

        private readonly JsonSerializerSettings jsonConverterSettings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                Converters.FlightTrackingStatusConverter.Instance,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };

        internal class RangeQuery
        {
            public double Latitude { get; private set; }

            public double Longitude { get; private set; }

            public int Distance { get; private set; }

            public RangeQuery(double lat, double lng, int distance)
            {
                Latitude = lat;
                Longitude = lng;
                Distance = distance;
            }
        }
    }


}
