using System;
using UnityEngine;

public class CGDataController : CGSingleton<CGDataController>
{
    private CGItemButton[] itemButtons;

    protected override void OnAwake()
    {
        itemButtons = UnityEngine.Object.FindObjectsByType<CGItemButton>(FindObjectsSortMode.None);
    }

    void Start()
    {
        Point += GetTotalPointPerSec() * TimeAfterLastPlay;
        InvokeRepeating("UpdateLastPlayerDate", 0f, 5f);
    }

    public void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }

    //
    // Point Section
    //

    public long Point
    {
        get
        {
            if (PlayerPrefs.HasKey(CGPlayerPrefKeys.Point))
            {
                string loaded = PlayerPrefs.GetString(CGPlayerPrefKeys.Point);
                return long.Parse(loaded);
            }
            else
            {
                return 0;
            }
        }
        set
        {
            PlayerPrefs.SetString(CGPlayerPrefKeys.Point, value.ToString());
        }
    }

    //
    // PerClick Section
    //

    public long PerClick
    {
        get
        {
            if (PlayerPrefs.HasKey(CGPlayerPrefKeys.PerClick))
            {
                string loaded = PlayerPrefs.GetString(CGPlayerPrefKeys.PerClick);
                return long.Parse(loaded);
            }
            else
            {
                return 1;
            }
        }
        set
        {
            PlayerPrefs.SetString(CGPlayerPrefKeys.PerClick, value.ToString());
        }
    }

    //
    // Item Buttons Section
    //

    public int GetTotalPointPerSec()
    {
        int totalPointPerSec = 0;
        for (int i = 0; i < itemButtons.Length; i++)
        {
            if (itemButtons[i].isPurchased == true)
            {
                totalPointPerSec += itemButtons[i].pointPerSec;
            }
            totalPointPerSec += itemButtons[i].pointPerSec;
        }

        return totalPointPerSec;
    }

    //
    // Upgrade Button Section
    //

    public void LoadUpgradeButton(CGUpgradeButton inUpgrade)
    {
        string keyLevel = CGPlayerPrefKeys.GetLevelKey(inUpgrade);
        string keyPointByUpgrade = CGPlayerPrefKeys.GetPointbyUpgradeKey(inUpgrade);
        string keyCurrentCost = CGPlayerPrefKeys.GetCurrentCostKey(inUpgrade);

        inUpgrade.level = PlayerPrefs.GetInt(keyLevel);
        inUpgrade.pointByUpgrade = PlayerPrefs.GetInt(keyPointByUpgrade, inUpgrade.startPointByUpgrade);
        inUpgrade.currentCost = PlayerPrefs.GetInt(keyCurrentCost, inUpgrade.startCurrentCost);
    }

    public void SaveUpgradeButton(CGUpgradeButton inUpgrade)
    {
        string keyLevel = CGPlayerPrefKeys.GetLevelKey(inUpgrade);
        string keyPointByUpgrade = CGPlayerPrefKeys.GetPointbyUpgradeKey(inUpgrade);
        string keyCurrentCost = CGPlayerPrefKeys.GetCurrentCostKey(inUpgrade);

        PlayerPrefs.SetInt(keyLevel, inUpgrade.level);
        PlayerPrefs.SetInt(keyPointByUpgrade, inUpgrade.pointByUpgrade);
        PlayerPrefs.SetInt(keyCurrentCost, inUpgrade.currentCost);
    }

    //
    // Item Button Section
    //

    public void LoadItemButton(CGItemButton inItem)
    {
        string keyLevel = CGPlayerPrefKeys.GetLevelKey(inItem);
        string keyCurrentCost = CGPlayerPrefKeys.GetCurrentCostKey(inItem);
        string keyPointPerSec = CGPlayerPrefKeys.GetPointPerSecKey(inItem);
        string keyIsPurchased = CGPlayerPrefKeys.GetCurrentCostKey(inItem);

        inItem.level = PlayerPrefs.GetInt(keyLevel, 1);
        inItem.currentCost = PlayerPrefs.GetInt(keyCurrentCost, inItem.startCurrentCost);
        inItem.pointPerSec = PlayerPrefs.GetInt(keyPointPerSec, inItem.startPointPerSec);

        if (PlayerPrefs.GetInt(keyIsPurchased) == 1)
        {
            inItem.isPurchased = true;
        }
        else
        {
            inItem.isPurchased = false;
        }
    }

    public void SaveItemButton(CGItemButton inItem)
    {
        string keyLevel = CGPlayerPrefKeys.GetLevelKey(inItem);
        string keyCurrentCost = CGPlayerPrefKeys.GetCurrentCostKey(inItem);
        string keyPointPerSec = CGPlayerPrefKeys.GetPointPerSecKey(inItem);
        string keyIsPurchased = CGPlayerPrefKeys.GetCurrentCostKey(inItem);

        PlayerPrefs.SetInt(keyLevel, inItem.level);
        PlayerPrefs.SetInt(keyCurrentCost, inItem.currentCost);
        PlayerPrefs.SetInt(keyPointPerSec, inItem.pointPerSec);

        if (inItem.isPurchased == true)
        {
            PlayerPrefs.SetInt(keyIsPurchased, 1);
        }
        else
        {
            PlayerPrefs.SetInt(keyIsPurchased, 0);
        }
    }

    //
    // Time After Last Play Section
    //
    public int TimeAfterLastPlay
    {
        get
        {
            DateTime currentTime = DateTime.Now;
            DateTime lastPlayDate = GetLastPlayerDate();

            return (int)currentTime.Subtract(lastPlayDate).TotalSeconds;
        }    
    }

    DateTime GetLastPlayerDate()
    {
        if (!PlayerPrefs.HasKey(CGPlayerPrefKeys.GetTimeKey()))
        {
            return DateTime.Now;
        }

        string timeBinaryInString = PlayerPrefs.GetString(CGPlayerPrefKeys.GetTimeKey());
        long timeBinaryInLong = Convert.ToInt64(timeBinaryInString);

        return DateTime.FromBinary(timeBinaryInLong);
    }

    void UpdateLastPlayerDate()
    {
        PlayerPrefs.SetString(CGPlayerPrefKeys.GetTimeKey(), DateTime.Now.ToBinary().ToString());
    }

    void OnApplicationQuit()
    {
        UpdateLastPlayerDate();
    }
}
