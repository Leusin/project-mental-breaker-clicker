using UnityEngine;

public class MBGameDayTracker
{
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

        Debug.Log($"[Day {InGameDay}] 하루 경과!");

        // 여기에 이벤트 트리거 연결
        TryTriggerRandomEvent(InGameDay);
    }

    private void TryTriggerRandomEvent(int day)
    {
        // 예: 3일차부터 매일 50% 확률로 이벤트 발생
        if (day >= 3 && Random.value < 0.5f)
        {
            TriggerRandomEvent();
        }
    }

    private void TriggerRandomEvent()
    {
        Debug.Log("랜덤 이벤트 발생!");
        // TODO: 선택지 + 대사 띄우기
    }
}
