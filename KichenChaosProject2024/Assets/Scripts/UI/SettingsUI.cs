using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SettingsUI : MonoBehaviour
{
    public static SettingsUI instance { get; private set; }
    [SerializeField] private GameObject uiParent;
    [SerializeField] private Button soundButton;
    [SerializeField] private TextMeshProUGUI soundButtonText;
    [SerializeField] private Button musicButton;
    [SerializeField] private TextMeshProUGUI musicButtonText;
    [SerializeField] private Button closeButton;

    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        Hide();
        UpdateVisual();
        soundButton.onClick.AddListener(() =>
        {
            SoundManager.instance.ChangeVolume();
            UpdateVisual();
        });
        musicButton.onClick.AddListener(() =>
        {
            MusicManager.instance.changeVolume();
            UpdateVisual();
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
    private void UpdateVisual()
    {
        soundButtonText.text="音量大小："+SoundManager.instance.GetVolume();
        musicButtonText.text="音乐大小："+MusicManager.instance.GetVolume();
    }
}
