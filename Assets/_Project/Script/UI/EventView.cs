using TMPro;
using UnityEngine;

namespace _Project.Script.UI
{
    public class EventView : MonoBehaviour
    {
        [field: SerializeField]
        public TextMeshProUGUI TitleText { get; private set; }
        [field: SerializeField]
        public TextMeshProUGUI EndDateText { get; private set; }

        public void Init(string title, string endDate)
        {
            TitleText.text = title;
            EndDateText.text = endDate;
        }
    }
}