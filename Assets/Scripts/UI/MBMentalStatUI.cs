using UnityEngine;
using TMPro;


public class MBMentalStatUI : MonoBehaviour
{
    public TMP_Text mentalPointVal;
    public TMP_Text mentalPointPerSecVal;
    public TMP_Text mentalLevelVal;
    public TMP_Text mentalMoodVal;
    public TMP_Text mentalStateVal;

    private MBMentalStatData _mentalStat;

    void Start()
    {
        _mentalStat = MBDataManager.Instance.MentalStats;
    }

    void Update()
    {
        mentalPointVal.text = _mentalStat.MentalPoint.ToString();
        mentalPointPerSecVal.text = _mentalStat.PerSec.ToString();
        mentalLevelVal.text = _mentalStat.Level.ToString();
        mentalMoodVal.text = ((int)_mentalStat.Mood).ToString();
        mentalStateVal.text = _mentalStat.MentalState.ToString();
    }
}
