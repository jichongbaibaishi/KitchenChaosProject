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


    [SerializeField] private Button upKeyButton;
    [SerializeField] private Button downKeyButton;
    [SerializeField] private Button leftKeyButton;
    [SerializeField] private Button rightKeyButton;
    [SerializeField] private Button interactKeyButton;
    [SerializeField] private Button operateKeyButton;
    [SerializeField] private Button pauseKeyButton;

    [SerializeField] private TextMeshProUGUI upKeyButtonText;
    [SerializeField] private TextMeshProUGUI downKeyButtonText;
    [SerializeField] private TextMeshProUGUI leftKeyButtonText;
    [SerializeField] private TextMeshProUGUI rightKeyButtonText;
    [SerializeField] private TextMeshProUGUI interactKeyButtonText;
    [SerializeField] private TextMeshProUGUI operateKeyButtonText;
    [SerializeField] private TextMeshProUGUI pauseKeyButtonText;

    [SerializeField]private GameObject reBindingwint;
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
        upKeyButton.onClick.AddListener(() =>
        {
            ReBinding(GameInput.BindingType.Up);
           
   
        });
        downKeyButton.onClick.AddListener(() =>
        {ReBinding(GameInput.BindingType.Down);
        });
        leftKeyButton.onClick.AddListener(() =>
        {
            ReBinding(GameInput.BindingType.Left);
        });
        rightKeyButton.onClick.AddListener(() =>
        {
            ReBinding(GameInput.BindingType.Right);
        });
        operateKeyButton.onClick.AddListener(() =>
        {
            ReBinding(GameInput.BindingType.Operate);
        });
        pauseKeyButton.onClick.AddListener(() =>
        {
            ReBinding(GameInput.BindingType.Pause);
        });
        interactKeyButton.onClick.AddListener(() =>
        {
            ReBinding(GameInput.BindingType.Interact);
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
        soundButtonText.text="音效大小:"+SoundManager.instance.GetVolume();
        musicButtonText.text="音乐大小:"+MusicManager.instance.GetVolume();

        upKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Up);
        downKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Down);
        leftKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Left);
        rightKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Right);
        interactKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Interact);
        operateKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Operate);
        pauseKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Pause);
    }
    private void ReBinding(GameInput.BindingType bindingType)
    {
        reBindingwint.SetActive(true);
        GameInput.instance.ReBinding(bindingType, () =>
        {
            reBindingwint.SetActive(false);
            UpdateVisual();
        });
    }
}
