using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 버튼 클릭 시 UpgradeController 호출
/// </summary>
public class MBUpgradeUIEntry : MonoBehaviour
{
    public TMP_Text levelText;
    public TMP_Text nameText;
    public TMP_Text flavorText;
    public TMP_Text descText;
    public TMP_Text costText;
    public Button buyButton;

    private MBUpgradeRuntimeData _data;
    private System.Action<MBUpgradeRuntimeData> _onBuyCallback;

    public void Setup(MBUpgradeRuntimeData upgrade, System.Action<MBUpgradeRuntimeData> onBuy)
    {
        _data = upgrade;
        _onBuyCallback = onBuy;

        levelText.text = upgrade.Level.ToString();
        nameText.text = upgrade.data.upgradeName;
        flavorText.text = upgrade.data.flavorText;
        descText.text = upgrade.data.description;
        costText.text = $"MP {upgrade.CurrentCost}";

        buyButton.onClick.AddListener(() => _onBuyCallback?.Invoke(_data));
    }
}
