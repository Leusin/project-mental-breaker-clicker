using UnityEngine;
using TMPro;

public class CGUIManager : MonoBehaviour
{
    public TMP_Text pointDisplayer;
    public TMP_Text perClickDisplayer;
    public TMP_Text perSecDisplayer;

    void Update()
    {
        //pointDisplayer.text = "POINT: " + dataController.GetPoint();
        pointDisplayer.text = $"POINT: {CGDataController.Instance.Point}";
        perClickDisplayer.text = $"PER CLICK: {CGDataController.Instance.PerClick}";
        perSecDisplayer.text = $"PER SEC: {CGDataController.Instance.GetTotalPointPerSec()}";
    }
}

