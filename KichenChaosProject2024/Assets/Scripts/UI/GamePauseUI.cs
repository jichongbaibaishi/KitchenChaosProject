using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;
    [SerializeField] private Button resumeButton;
    [SerializeField] private Button menuButton;
    private void Start()
    {
        Hide();
        GameMananger.instance.onGamePaused += GameManager_onGamePaused;
        GameMananger.instance.onGameUnpaused += GameManager_onGameUnpaused; ;
        resumeButton.onClick.AddListener(() =>
        {
            GameMananger.instance.TiggleGame();
        }
        );
        menuButton.onClick.AddListener(() =>
        {
            Loader.Load(Loader.Scene.GameMenuScene);
        }
       );
    }

    private void GameManager_onGameUnpaused(object sender, System.EventArgs e)
    {
        Hide();
    }

    private void GameManager_onGamePaused(object sender, System.EventArgs e)
    {
        Show();
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
