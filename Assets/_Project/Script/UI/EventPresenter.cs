using System.Collections.Generic;
using _Project.Script.Core;
using _Project.Script.Core.EntryPoints;

namespace _Project.Script.UI
{
    public class EventPresenter
    {
        private readonly RootCanvas _rootCanvas;
        private readonly EventView _eventViewPrefab;
        private readonly UIFactory _uiFactory;

        public EventPresenter(RootCanvas rootCanvas, EventView eventViewPrefab, UIFactory uiFactory)
        {
            _rootCanvas = rootCanvas;
            _eventViewPrefab = eventViewPrefab;
            _uiFactory = uiFactory;
        }

        public void Init(Dictionary<EventType, EventConfig> events)
        {
            foreach (var gameEvent in events)
            {
                var view = _uiFactory.CreateUI<EventView>(_eventViewPrefab, _rootCanvas.SpawnParent);
                view.Init(gameEvent.Value.HolidayType.ToString(), gameEvent.Value.EndDate.ToString());
            }
        }
    }
}