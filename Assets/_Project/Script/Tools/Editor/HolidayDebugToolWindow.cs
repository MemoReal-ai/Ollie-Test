#if UNITY_EDITOR
using System;
using _Project.Script.Core;
using _Project.Script.Core.EntryPoints;
using UnityEditor;
using UnityEngine;

namespace _Project.Script.Tools.Editor
{
    public class HolidayDebugToolWindow : EditorWindow
    {
        private GameEventProvider _eventProvider;
        private IJsonService _jsonService;

        private int _timeShiftDays = 0;
        private int _timeShiftHours = 0;

        [MenuItem("Tools/Holiday Debug Tool")]
        public static void ShowWindow()
        {
            GetWindow<HolidayDebugToolWindow>("Holiday Debug Tool");
        }

        private void OnEnable()
        {
            _jsonService = new JsonService();
            _eventProvider = new GameEventProvider(_jsonService);
        }

        private void OnGUI()
        {
            GUILayout.Label("🛠 Holiday Debug Tool", EditorStyles.boldLabel);

            GUILayout.Label("Time Shift (Days):");
            _timeShiftDays = EditorGUILayout.IntSlider(_timeShiftDays, -360, 360);

            GUILayout.Label("Time Shift (Hours):");
            _timeShiftHours = EditorGUILayout.IntSlider(_timeShiftHours, -23, 23);

            DateTime currentTime = DateTime.UtcNow.AddDays(_timeShiftDays).AddHours(_timeShiftHours);
            GUILayout.Label($"Current UTC time (with shift): {currentTime:yyyy-MM-dd HH:mm:ss}");

            var activeHolidays = _eventProvider.LoadEventsDef(currentTime);

            GUILayout.Label("Active Holidays:");
            if (activeHolidays.Count == 0)
            {
                GUILayout.Label("— No active holidays —");
            }
            else
            {
                foreach (var holiday in activeHolidays.Keys)
                {
                    GUILayout.Label($"• {holiday.ToString().ToUpper()}");
                }
            }

            GUILayout.Space(10);
            if (GUILayout.Button("Refresh"))
            {
                Repaint();
            }
        }
    }
}
#endif