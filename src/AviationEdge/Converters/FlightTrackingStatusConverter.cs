using AviationEdge.Models;
using AviationEdge.Models.FlightTracking;
using Newtonsoft.Json;
using System;

namespace AviationEdge.Converters
{
    internal class FlightTrackingStatusConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(FlightTrackingStatus) || t == typeof(FlightTrackingStatus?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "en-route":
                    return FlightTrackingStatus.EnRoute;
                case "landed":
                    return FlightTrackingStatus.Landed;
                case "started":
                    return FlightTrackingStatus.Started;
                case "unknown":
                    return FlightTrackingStatus.Unknown;
            }
            throw new Exception("Cannot unmarshal type Status");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (FlightTrackingStatus)untypedValue;
            switch (value)
            {
                case FlightTrackingStatus.EnRoute:
                    serializer.Serialize(writer, "en-route");
                    return;
                case FlightTrackingStatus.Landed:
                    serializer.Serialize(writer, "landed");
                    return;
                case FlightTrackingStatus.Started:
                    serializer.Serialize(writer, "started");
                    return;
                case FlightTrackingStatus.Unknown:
                    serializer.Serialize(writer, "unknown");
                    return;
            }
            throw new Exception("Cannot marshal type Status");
        }

        public static readonly FlightTrackingStatusConverter Instance = new FlightTrackingStatusConverter();
    }
}
