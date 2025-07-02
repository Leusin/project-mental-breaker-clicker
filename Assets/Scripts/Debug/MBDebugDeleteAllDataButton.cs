using UnityEngine;
using UnityEngine.UI;

public class MBDebugDeleteAllDataButton : MonoBehaviour
{
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(MBDataManager.Instance.DeleteAllData);
    }

}
