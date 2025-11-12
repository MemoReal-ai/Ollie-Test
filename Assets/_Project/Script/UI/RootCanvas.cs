using UnityEngine;

namespace _Project.Script.UI
{
    public class RootCanvas : MonoBehaviour
    {
        [field: SerializeField]
        public RectTransform SpawnParent { get; private set; }
    }
}