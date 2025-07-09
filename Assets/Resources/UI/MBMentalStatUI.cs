using UnityEngine;
using TMPro;


public class MBMentalStatUI : MonoBehaviour
{
    public TMP_Text mentalPointVal;
    public TMP_Text mentalLevelVal;
    public TMP_Text mentalMoodVal;
    public TMP_Text mentalStateVal;

    private MBMentalStatData _data;

    void Start()
    {
        _data = MBDataManager.Instance.MentalStats;
    }

    void Update()
    {
        mentalPointVal.text = $"{_data.MentalPoint}";
        mentalLevelVal.text = $"{_data.Level}";
        mentalMoodVal.text = $"{_data.Mood}";
        mentalStateVal.text = $"{_data.MentalState.ToString()}";
    }
}
