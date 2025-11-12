using UnityEngine;

namespace _Project.Script.Core.EntryPoints
{
    public class RootCanvas : MonoBehaviour
    {
        [field: SerializeField]
        public RectTransform SpawnParent { get; private set; }
    }
}