using UnityEngine;
using Zenject;

namespace _Project.Script.UI
{
    public class UIFactory
    {
        private readonly IInstantiator _instantiator;

        public UIFactory(IInstantiator instantiator)
        {
            _instantiator = instantiator;
        }

        public T CreateUI<T>(Object prefab, RectTransform parent)
        {
            return _instantiator.InstantiatePrefabForComponent<T>(prefab, parent);
        }
    }
}