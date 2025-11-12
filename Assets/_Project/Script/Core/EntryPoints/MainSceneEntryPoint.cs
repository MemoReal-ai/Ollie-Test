using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace _Project.Script.Core.EntryPoints
{
    public class MainSceneEntryPoint : IInitializable
    {
        private Dictionary<EventType, EventConfig> events = new Dictionary<EventType, EventConfig>();
        private IGameEventProvider _eventProvider;
        private EventPresenter _presenter;

        public MainSceneEntryPoint(IGameEventProvider eventProvider, EventPresenter presenter)
        {
            _eventProvider = eventProvider;
            _presenter = presenter;
        }

        public void Initialize()
        {
            events = _eventProvider.LoadEventsDef();
            if (events == null)
            {
                Debug.LogWarning("No found current event ");
                return;
            }
            _presenter.Init(events);
        }
    }
}