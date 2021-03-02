using NUnit.Framework;
using System.Threading;

namespace AviationEdge.Tests
{
    public class Tests
    {
        private const string API_KEY = "";
        private AviationEdgeClient client;

        [SetUp]
        public void Setup()
        {
            client = new AviationEdgeClient(API_KEY);
        }

        [Test]
        public void FlightTrackingByDepartureICAO()
        {
            var gatwickDepartures = client.FlightTrackerClient.DepartureAirport("egkk", CodeType.ICAO).Query(CancellationToken.None).Result;
            Assert.NotNull(gatwickDepartures);
        }

        [Test]
        public void FlightTrackingByDepartureIATA()
        {
            var gatwickDepartures = client.FlightTrackerClient.DepartureAirport("LGW", CodeType.IATA).Limit(50).Query(CancellationToken.None).Result;
            Assert.NotNull(gatwickDepartures);
        }

        [Test]
        public void FlightTrackingByAirlineICAO()
        {
            var gatwickDepartures = client.FlightTrackerClient.Airline("EZY", CodeType.ICAO).Limit(50).Query(CancellationToken.None).Result;
            Assert.NotNull(gatwickDepartures);
        }









        [Test]
        public void ScheduleByAirline()
        {
            var gatwickDepartures = client.SchedulesClient.DepartureAirport("egkk", CodeType.ICAO).Query(CancellationToken.None).Result;
            Assert.NotNull(gatwickDepartures);
        }
    }
}