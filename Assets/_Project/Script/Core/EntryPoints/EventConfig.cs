using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace _Project.Script.Core.EntryPoints
{
    [Serializable]
    public class EventConfig
    {
        public EventType HolidayType;
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime StartDate;
        [JsonConverter(typeof(IsoDateTimeConverter))]
        public DateTime EndDate;
    }
}