using UnityEngine;

public class MBMentalStatData
{
    public long MentalXP
    {
        get
        {
            if (PlayerPrefs.HasKey(MBPlayerPrefKeys.MentalXp))
            {
                string loaded = PlayerPrefs.GetString(MBPlayerPrefKeys.MentalXp);
                return long.Parse(loaded);
            }
            else
            {
                return 0;
            }
        }
        set
        {
            PlayerPrefs.SetString(MBPlayerPrefKeys.MentalXp, value.ToString());
        }
    }
}
