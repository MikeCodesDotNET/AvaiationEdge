using AviationEdge.Models.FlightTracking;
using AviationEdge.Models.Schedules;
using Flurl;
using Flurl.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;

namespace AviationEdge
{
    public class SchedulesClient
    {
        Dictionary<string, object> queryParams = new Dictionary<string, object>();
        private string _apiKey;
        private string _endpoint;

        internal SchedulesClient(string endpoint, string apiKey)
        {
            _endpoint = endpoint;
            _apiKey = apiKey;
        }


        /// <summary>
        /// The  departure airport (KJFK, EHAM, LFPG, or JFK, AMS, CDG, etc)
        /// </summary>
        /// <param name="code"></param>
        /// <param name="codeType"></param>
        /// <returns></returns>
        public SchedulesClient DepartureAirport(string code, CodeType codeType)
        {
            if (codeType == CodeType.IATA)
            {
                queryParams.Add("iataCode", code);
            }
            if (codeType == CodeType.ICAO)
            {
                queryParams.Add("icaoCode", code);
            }

            queryParams.Add("type", "departure");
            return this;
        }

        /// <summary>
        /// The terminal at the departure airport (1, 2, 3, 4, etc)
        /// </summary>
        /// <param name="terminal"></param>
        /// <returns></returns>
        public SchedulesClient DepatureTerminal(string terminal)
        {
            queryParams.Add("dep_terminal", terminal);
            return this;
        }

        /// <summary>
        /// The delay in minutes at departure (10, 20, 45, etc) it is not possible to set a delay range
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        public SchedulesClient DepatureDelay(TimeSpan delay)
        {
            queryParams.Add("dep_delay", delay.TotalMinutes);
            return this;
        }

        /// <summary>
        /// The scheduled flight's departure in the following format: YYYY-MM-DDT00:00:00.000 For example: 2019-06-07T05:00:00.000
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        public SchedulesClient ScheduledDepature(DateTime time)
        {
            queryParams.Add("dep_schTime", time);
            return this;
        }

        /// <summary>
        /// The estimated departure time in the following format: YYYY-MM-DDT00:00:00.000 For example: 2019-06-07T05:00:00.000
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public SchedulesClient EstimatedDeparture(DateTime time)
        {
            queryParams.Add("dep_estTime", time);
            return this;
        }

        /// <summary>
        /// The actual flight departure time in the following format: YYYY-MM-DDT00:00:00.000 For example: 2019-06-07T05:00:00.000
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public SchedulesClient ActualFlightDepartureTime(DateTime time)
        {
            queryParams.Add("dep_actTime", time);
            return this;
        }

        /// <summary>
        /// The estimated departure time at runway in the following format: YYYY-MM-DDT00:00:00.000 For example: 2019-06-07T05:00:00.000
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public SchedulesClient EstimatedDepartureTimeAtRunway(DateTime time)
        {
            queryParams.Add("dep_estRunway", time);
            return this;
        }

        /// <summary>
        /// The actual departure time at runway in the following format: YYYY-MM-DDT00:00:00.000 For example: 2019-06-07T05:00:00.000
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public SchedulesClient ActualDepartureTimeAtRunway(DateTime time)
        {
            queryParams.Add("dep_actRunway", time);
            return this;
        }


        /// <summary>
        /// The  departure airport (KJFK, EHAM, LFPG, or JFK, AMS, CDG, etc)
        /// </summary>
        /// <param name="code"></param>
        /// <param name="codeType"></param>
        /// <returns></returns>
        public SchedulesClient ArrivalAirport(string code, CodeType codeType)
        {
            if (codeType == CodeType.IATA)
            {
                queryParams.Add("dep_iataCode", code);
            }
            if (codeType == CodeType.ICAO)
            {
                queryParams.Add("dep_icaoCode", code);
            }
            return this;
        }

        /// <summary>
        /// The terminal at the departure airport (1, 2, 3, 4, etc)
        /// </summary>
        /// <param name="terminal"></param>
        /// <returns></returns>
        public SchedulesClient ArrivalTerminal(string terminal)
        {
            queryParams.Add("dep_terminal", terminal);
            return this;
        }

        /// <summary>
        /// The delay in minutes at departure (10, 20, 45, etc) it is not possible to set a delay range
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        public SchedulesClient ArrivalDelay(TimeSpan delay)
        {
            queryParams.Add("dep_delay", delay.TotalMinutes);
            return this;
        }

        /// <summary>
        /// The scheduled flight's departure in the following format: YYYY-MM-DDT00:00:00.000 For example: 2019-06-07T05:00:00.000
        /// </summary>
        /// <param name="delay"></param>
        /// <returns></returns>
        public SchedulesClient ScheduledArrival(DateTime time)
        {
            queryParams.Add("dep_schTime", time);
            return this;
        }

        /// <summary>
        /// The estimated departure time in the following format: YYYY-MM-DDT00:00:00.000 For example: 2019-06-07T05:00:00.000
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public SchedulesClient EstimatedArrival(DateTime time)
        {
            queryParams.Add("dep_estTime", time);
            return this;
        }

        /// <summary>
        /// The actual flight departure time in the following format: YYYY-MM-DDT00:00:00.000 For example: 2019-06-07T05:00:00.000
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public SchedulesClient ActualFlightArrivalTime(DateTime time)
        {
            queryParams.Add("dep_actTime", time);
            return this;
        }

        /// <summary>
        /// The estimated departure time at runway in the following format: YYYY-MM-DDT00:00:00.000 For example: 2019-06-07T05:00:00.000
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public SchedulesClient EstimatedArrivalTimeAtRunway(DateTime time)
        {
            queryParams.Add("dep_estRunway", time);
            return this;
        }

        /// <summary>
        /// The actual departure time at runway in the following format: YYYY-MM-DDT00:00:00.000 For example: 2019-06-07T05:00:00.000
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public SchedulesClient ActualArrivalTimeAtRunway(DateTime time)
        {
            queryParams.Add("dep_actRunway", time);
            return this;
        }

        /// <summary>
        /// Name of the airline (Air France, American Airlines, Delta Air Lines, etc)
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SchedulesClient Airline(string name)
        {
            queryParams.Add("airline_name", name);
            return this;
        }


        public SchedulesClient Airline(string code, CodeType codeType)
        {
            if (codeType == CodeType.IATA)
            {
                queryParams.Add("airline_iata", code);
            }
            if (codeType == CodeType.ICAO)
            {
                queryParams.Add("airline_icao", code);
            }
            return this;
        }

        public SchedulesClient FlightNumber(string name)
        {
            queryParams.Add("flight_num", name);
            return this;
        }

        public SchedulesClient Flight(string code, CodeType codeType)
        {
            if (codeType == CodeType.IATA)
            {
                queryParams.Add("flight_iata", code);
            }
            if (codeType == CodeType.ICAO)
            {
                queryParams.Add("flight_icao", code);
            }
            return this;
        }


        public async Task<IEnumerable<ScheduleResponse>> Query(CancellationToken ct)
        {
            var jsonResult = await _endpoint
                            .AppendPathSegment("flights")
                            .SetQueryParam("key", _apiKey)
                            .SetQueryParams(queryParams)
                            .GetStringAsync(ct);

            return JsonConvert.DeserializeObject<List<ScheduleResponse>>(jsonResult, jsonConverterSettings);
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

    }


}
