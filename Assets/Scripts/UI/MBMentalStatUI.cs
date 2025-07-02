using UnityEngine;
using TMPro;


public class MBMentalStatUI : MonoBehaviour
{
    public TMP_Text mentalXpText;
    private MBMentalStatData _data;

    void Start()
    {
        _data = MBDataManager.Instance.MentalStats;
    }

    void Update()
    {
        mentalXpText.text = $"Mental XP : {_data.MentalXP}";
    }
}
