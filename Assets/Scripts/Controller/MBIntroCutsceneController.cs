using UnityEngine;
using UnityEngine.UI;
public class MBIntroCutsceneController : MonoBehaviour
{
    public Image blackBackground;

    void Start()
    {
        FadeUtil.FadeIn(blackBackground, 2.0f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
