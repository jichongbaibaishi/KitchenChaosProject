using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameClockUI : MonoBehaviour
{
    [SerializeField]private GameObject uiParent;
    [SerializeField]private Image progressImage;
    [SerializeField]private TextMeshProUGUI timeText;
    private void Start()
    {
        GameMananger.instance.onStateChanged += GameManager_onStateChanged;
        Hide();
    }

    private void Update()
    {
        if (GameMananger.instance.IsGamePlayingState())
        {
            progressImage.fillAmount = GameMananger.instance.GetGamePlayingTimerNormalized();
            timeText.text = Mathf.CeilToInt(GameMananger.instance.GetGamePlayingTimer()).ToString();
        }
    }

    private void GameManager_onStateChanged(object sender, System.EventArgs e)
    {
        if (GameMananger.instance.IsGamePlayingState())
        {
            Show();
        }
    }

   

    private void Show()
    {
        uiParent.SetActive(true);
    }
    private void Hide()
    {
        uiParent.SetActive(false);
    }
}
