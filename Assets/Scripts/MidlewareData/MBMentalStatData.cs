using UnityEngine;

public enum MBMentalState
{
    Depressed = 0, // 시작 상태
    Numb = 1, // 무기력 단계
    Acceptance = 2, // 수용 단계
    SelfLove = 3, // 자기애 단계
    Transcendence = 4 // 초월 단계
}

public class MBMentalStatData
{

    /// <summary>
    /// 클릭/업그레이드/이벤트 등으로 얻는 멘탈 포인트. 업그레이드 자원으로 사용
    /// 범위 : 0 ~ 무한
    /// </summary>
    public long MentalPoint
    {
        get
        {
            if (PlayerPrefs.HasKey(MBPlayerPrefKeys.MentalPoint))
            {
                string loaded = PlayerPrefs.GetString(MBPlayerPrefKeys.MentalPoint);
                return long.Parse(loaded);
            }
            else
            {
                return 0;
            }
        }
        set
        {
            PlayerPrefs.SetString(MBPlayerPrefKeys.MentalPoint, value.ToString());
        }
    }

    public long PerSec
    {
        get
        {
            if (PlayerPrefs.HasKey(MBPlayerPrefKeys.PerSec))
            {
                return long.Parse(PlayerPrefs.GetString(MBPlayerPrefKeys.PerSec));
            }
            else
            {
                return 0;
            }
        }
        set
        {
            PlayerPrefs.SetString(MBPlayerPrefKeys.PerSec, value.ToString());
        }
    }

    /// <summary>
    /// 클릭당 MP 획득량을 결정함
    /// 범위 : 1~
    /// </summary>
    public int Level
    {
        get
        {
            if (PlayerPrefs.HasKey(MBPlayerPrefKeys.MentalLevel))
            {
                string loaded = PlayerPrefs.GetString(MBPlayerPrefKeys.MentalLevel);
                return int.Parse(loaded);
            }
            else
            {
                return 0;
            }
        }
        set
        {
            PlayerPrefs.SetString(MBPlayerPrefKeys.MentalLevel, value.ToString());
            CheckMentalStateChange();
        }
    }

    /// <summary>
    /// 현재 기분 상태. 감정 표현, 선택지, 이벤트 분기에 영향
    /// -100 ~ 100
    /// 트리거 조건
    /// - Take A Deep Breathe: +0.2
    /// - Habit Upgrade: +0.05
    /// - [미구현] 접속하지 않은 날 만큼 피보나치 수열로 줄어듦. 대신 -20 + 레벨 * 15 보다 떨어지면 안됨
    /// </summary>
    public float Mood
    {
        get
        {
            if (PlayerPrefs.HasKey(MBPlayerPrefKeys.MentalMood))
            {
                return PlayerPrefs.GetFloat(MBPlayerPrefKeys.MentalMood);
            }
            else
            {
                return -100f; // 기본값: 우울 상태
            }
        }
        set
        {
            value = Mathf.Clamp(value, -100f, 100f);
            PlayerPrefs.SetFloat(MBPlayerPrefKeys.MentalMood, value);
            CheckMentalStateChange();
        }
    }

    /// <summary>
    /// 현재 스토리 진행 단계
    /// </summary>
    public MBMentalState MentalState
    {
        get
        {
            if (PlayerPrefs.HasKey(MBPlayerPrefKeys.MentalState))
            {
                string loaded = PlayerPrefs.GetString(MBPlayerPrefKeys.MentalState);
                return (MBMentalState)System.Enum.Parse(typeof(MBMentalState), loaded);
            }
            else
            {
                return MBMentalState.Depressed;
            }
        }
        set
        {
            PlayerPrefs.SetString(MBPlayerPrefKeys.MentalState, value.ToString());
        }
    }

    // TODO: 하드코딩된 값은 나중에 다른 자료형에서 불러오도록 변경
    private void CheckMentalStateChange()
    {
        long level = Level;
        int mood = (int)Mood;
        if (level >= 4 && mood >= 80)
        {
            MentalState = MBMentalState.Transcendence;
        }
        else if (level >= 3 && mood >= 50)
        {
            MentalState = MBMentalState.SelfLove;
        }
        else if (level >= 2 && mood >= 0)
        {
            MentalState = MBMentalState.Acceptance;
        }
        else if (level >= 1 && mood >= -70)
        {
            MentalState = MBMentalState.Numb;
        }
        else
        {
            MentalState = MBMentalState.Depressed;
        }
    }

}
