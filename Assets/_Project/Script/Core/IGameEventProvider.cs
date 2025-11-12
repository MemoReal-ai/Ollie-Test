using System;
using System.Collections.Generic;

namespace _Project.Script.Core
{
    public interface IGameEventProvider
    {
        Dictionary<EventType, EventConfig> LoadEventsDef(DateTime? overrideTime = null);
    }
}