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
        }
    }

    /// <summary>
    /// 현재 기분 상태. 감정 표현, 선택지, 이벤트 분기에 영향
    /// </summary>
    public float Mood
    {
        get
        {
            if (PlayerPrefs.HasKey(MBPlayerPrefKeys.MentalMood))
            {
                string loaded = PlayerPrefs.GetString(MBPlayerPrefKeys.MentalMood);
                return float.Parse(loaded);
            }
            else
            {
                return 0;
            }
        }
        set
        {
            PlayerPrefs.SetString(MBPlayerPrefKeys.MentalMood, value.ToString());
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
}
