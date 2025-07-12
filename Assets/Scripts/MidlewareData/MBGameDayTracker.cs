using System;
using UnityEngine;

public class MBGameDayTracker
{
    public event Action<int> OnNewDay;

    public int InGameDay
    {
        get => PlayerPrefs.GetInt(MBPlayerPrefKeys.GameDay, 0);
        private set => PlayerPrefs.SetInt(MBPlayerPrefKeys.GameDay, value);
    }

    public void IncreaseDailyActionCount()
    {
        DayilyActionCount++;

        if (DayilyActionCount >= _count_per_day)
        {
            AdvanceDay();
        }
    }

    private int DayilyActionCount
    {
        get
        {
            return PlayerPrefs.GetInt(MBPlayerPrefKeys.DayilyActionCount, 0);
        }
        set
        {
            PlayerPrefs.SetInt(MBPlayerPrefKeys.DayilyActionCount, value);
        }
    }

    private const int _count_per_day = 12;
    
    private void AdvanceDay()
    {
        InGameDay++;
        DayilyActionCount = 0;

        Debug.Log($"[GameDayTracker] 하루 경과: Day {InGameDay}");

        // 여기에 이벤트 트리거 연결
        TryTriggerRandomEvent(InGameDay);
    }

    private void TryTriggerRandomEvent(int day)
    {
        OnNewDay?.Invoke(day);
    }
}
