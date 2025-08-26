using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MBIntroCutsceneController : MonoBehaviour
{
    [SerializeField] private Image blackBackground;

    // MainUI
    [SerializeField] private Canvas mainUICanvas;
    [SerializeField] private GameObject TabBar;
    [SerializeField] private GameObject ButtonDeepBreathe;
    [SerializeField] private GameObject PanelMentalStat;
    [SerializeField] private GameObject PanelChat;

    private GameObject character;

    void Awake()
    {
        blackBackground.gameObject.SetActive(true);

        mainUICanvas = GameObject.Find("Canvas_Main").GetComponent<Canvas>();
        if (mainUICanvas != null)
        {
            TabBar = mainUICanvas.transform.Find("TabBar").gameObject;
            ButtonDeepBreathe = mainUICanvas.transform.Find("Home").gameObject.transform.Find("Button_DeepBreathe").gameObject;
            PanelMentalStat = mainUICanvas.transform.Find("Home").gameObject.transform.Find("Panel_MentalStat").gameObject;
            PanelChat = mainUICanvas.transform.Find("Home").gameObject.transform.Find("Panel_Chat").gameObject;

            TabBar.SetActive(false);
            ButtonDeepBreathe.SetActive(false);
            PanelMentalStat.SetActive(false);
            PanelChat.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Main UI Canvas not found!");
        }

        character = GameObject.Find("Character");
        if (character != null)
        {
            character.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Character GameObject not found!");
        }
    }

    void Start()
    {
        FadeUtil.FadeIn(blackBackground, 2.0f);
    }

    private IEnumerator PlayIntroSequence()
    {
        // TODO: 인트로 시퀀스 재생 로직 구현

        // 인트로 시퀀스 종료 후 추가 로직 구현
        PlayerPrefs.SetInt(MBPlayerPrefKeys.IntroPlayedKey, 1);
        PlayerPrefs.Save();

        //introCanvas.SetActive(false);
        //mainUICanvas.SetActive(true);

        yield return null;
    }
}
