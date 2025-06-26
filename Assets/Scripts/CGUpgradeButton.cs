using UnityEngine;
using TMPro;

public class CGUpgradeButton : MonoBehaviour
{
    //
    // UI Section
    //
    
    public TMP_Text upgradeDisplayer;

    //
    // Managed Data Section
    //

    public string upgradeName; // 데이터를 저장할 때 키로도 사용

    [HideInInspector]
    public int level = 1;

    [HideInInspector]
    public int pointByUpgrade;
    [HideInInspector]
    public int currentCost = 1;

    //
    //
    //

    public int startPointByUpgrade = 1;
    public int startCurrentCost = 1;

    public float upgradePow = 1.07f;
    public float costPow = 3.14f;

    void Start()
    {
        CGDataController.Instance.LoadUpgradeButton(this);
        UpdateUI();
    }

    public void PurchaseUpgrade()
    {
        if (CGDataController.Instance.Point >= currentCost)
        {
            CGDataController.Instance.Point -= currentCost;
            level++;
            CGDataController.Instance.PerClick += pointByUpgrade;

            UdateUpgrade();
            UpdateUI();
            CGDataController.Instance.SaveUpgradeButton(this);
        }
    }

    private void UdateUpgrade()
    {
        pointByUpgrade = startPointByUpgrade * (int)Mathf.Pow(upgradePow, level);
        currentCost = startCurrentCost * (int)Mathf.Pow(costPow, level);
    }

    private void UpdateUI()
    {
        upgradeDisplayer.text = $"[ {upgradeName} ]\nLevel: {level}\nCost: {currentCost}\nNext New  PointPerClick: {pointByUpgrade}";
    }
}
