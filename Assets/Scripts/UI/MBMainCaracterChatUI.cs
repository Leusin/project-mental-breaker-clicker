using System;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class MBMainCharacterChatUI : MonoBehaviour
{
    enum State
    {
        OnEvent,
        OffEvent
    }

    // UI 요소들
    public TextMeshProUGUI characterName;
    public TextMeshProUGUI chatText;
    public Transform choicesRoot;
    public GameObject choiceButtonPrefab;

    public void ShowEvent(MBRandomEventData e)
    {
        _state = State.OnEvent;

        // UI 업데이트
        //characterName.gameObject.SetActive(false);
        choicesRoot.gameObject.SetActive(true);
        chatText.text = e.description;

        // 선택지 버튼 생성
        foreach (var choice in e.choices)
        {
            GameObject btnObj = Instantiate(choiceButtonPrefab, choicesRoot);
            var btn = btnObj.GetComponent<Button>();
            var txt = btnObj.GetComponentInChildren<TMP_Text>();

            txt.text = choice.text;

            btn.onClick.AddListener(() =>
            {
                // 선택지 결과 적용
                _eventController.ApplyChoiceResult(choice);
                // UI 초기화
                //characterName.gameObject.SetActive(true);
                chatText.text = choice.resultText;
                HideChoices();

                _state = State.OffEvent;
            });
        }
    }

    private State _state = State.OffEvent;

    private MBRandomEventController _eventController;

    private void Start()
    {
        var dataManager = MBDataManager.Instance;

        _eventController = new MBRandomEventController(
            dataManager.GameDayTracker,
            dataManager.MentalStats,
            dataManager.RandomEventLists
        );
        _eventController.OnShowEvent += ShowEvent;

        HideChoices();
    }

    private void HideChoices()
    {
        foreach (Transform child in choicesRoot)
        {
            Destroy(child.gameObject);
        }
    }
}

