using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CGItemButton : MonoBehaviour
{
    //
    // Key Name
    //
    public string itemName;


    //
    // UI Section
    //

    public TMP_Text itemDisplayer;

    public CanvasGroup canvasGroup;
    public Slider slider;

    //
    // Managed Data Section
    //

    public int level;
    public int pointPerSec;
    [HideInInspector]
    public bool isPurchased = false;

    //
    //
    //

    [HideInInspector]
    public int currentCost = 1;
    public int startCurrentCost = 1;
    [HideInInspector]
    public int startPointPerSec = 1;
    public float costPow = 3.14f;
    public float upgradePow = 1.07f;


    void Awake()
    {
        slider ??= GetComponentInChildren<Slider>();
    }

    void Start()
    {
        currentCost = startCurrentCost;
        pointPerSec = startPointPerSec;

        StartCoroutine(AddPointLoop());

        CGDataController.Instance.LoadItemButton(this);
        UpdateItem();
        UpdateUI();
    }

    void Update()
    {
        UpdateUI();
    }

    public void PurchaseItem()
    {
        if (CGDataController.Instance.Point >= currentCost)
        {
            isPurchased = true;
            CGDataController.Instance.Point -= currentCost;
            level++;

            UpdateItem();
            UpdateUI();

            CGDataController.Instance.SaveItemButton(this);
        }
    }

    IEnumerator AddPointLoop()
    {
        while (true)
        {
            if (isPurchased)
            {
                CGDataController.Instance.Point += pointPerSec;
            }

            yield return new WaitForSeconds(1.0f);
        }
    }

    public void UpdateItem()
    {
        pointPerSec = startPointPerSec * (int)Mathf.Pow(level, upgradePow);
        currentCost = startCurrentCost * (int)Mathf.Pow(level, costPow);
    }

    public void UpdateUI()
    {
        itemDisplayer.text = $"[ {itemName} ]\nLevel: {level}\nCost: {currentCost}\nPointPerSec: {pointPerSec}";

        slider.minValue = 0;
        slider.maxValue = currentCost;

        slider.value = CGDataController.Instance.Point;

        canvasGroup.alpha = isPurchased ? 1.0f : 0.6f;
    }
}