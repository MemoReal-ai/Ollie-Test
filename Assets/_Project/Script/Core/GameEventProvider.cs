using System;
using System.Collections.Generic;
using _Project.Script.Core.EntryPoints;
using UnityEngine;

namespace _Project.Script.Core
{
    public class GameEventProvider : IGameEventProvider
    {
        private string _eventsConfig;
        private readonly IJsonService _jsonService;

        public GameEventProvider(IJsonService jsonService)
        {
            _jsonService = jsonService;
        }

        public Dictionary<EventType, EventConfig> LoadEventsDef(DateTime? overrideTime = null)
        {
            var events = new Dictionary<EventType, EventConfig>();
            var nowDate = overrideTime ?? DateTime.UtcNow;

            try
            {
                var textAsset = Resources.Load<TextAsset>("content");
                var eventWrapper = _jsonService.ParseJson<EventConfigWrapper>(textAsset.text);
                
                foreach (var eventConfig in eventWrapper.HolidaySchedule)
                {
                    if (nowDate >= eventConfig.StartDate && nowDate <= eventConfig.EndDate)
                    {
                        events[eventConfig.HolidayType] = eventConfig;
                    }
                }
            }
            catch (Exception e)
            {
                Debug.LogWarning($"Failed to load events: {e}");
            }

            return events;
        }
    }
}