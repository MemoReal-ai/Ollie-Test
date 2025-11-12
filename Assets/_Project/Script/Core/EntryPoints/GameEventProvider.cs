using System;
using System.Collections.Generic;
using UnityEngine;

namespace _Project.Script.Core.EntryPoints
{
    public class GameEventProvider : IGameEventProvider
    {
        private string _eventsConfig;
        private readonly IJsonService _jsonService;

        public GameEventProvider(IJsonService jsonService)
        {
            _jsonService = jsonService;
        }

        public Dictionary<EventType, EventConfig> LoadEventsDef()
        {
            var events = new Dictionary<EventType, EventConfig>();
            var nowDate = DateTime.UtcNow;
            try
            {
                _eventsConfig = Resources.Load<TextAsset>("content").text;
                var eventWrapper = _jsonService.ParseJson<EventConfigWrapper>(_eventsConfig);
                foreach (var eventConfig in eventWrapper.HolidaySchedule)
                {
                    if (nowDate < eventConfig.StartDate || nowDate > eventConfig.EndDate)
                        continue;
                    events.Add(eventConfig.HolidayType, eventConfig);
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning(e);
            }

            return events;
        }
    }
}