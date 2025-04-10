using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public static SettingsUI instance { get; private set; }
    [SerializeField] private GameObject uiParent;
    [SerializeField] private Button soundButton;
    [SerializeField] private Button musicButton;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Hide();
        soundButton.onClick.AddListener(() =>
        {
            SoundManager.instance.ChangeVolume();
        });
        musicButton.onClick.AddListener(() =>
        {

        });
        closeButton.onClick.AddListener(() =>
        {
            Hide();
        });
     
    }

    public void Show()
    {
        uiParent.SetActive(true);
    }
    private void Hide()
    {
        uiParent.SetActive(false);
    }

}
