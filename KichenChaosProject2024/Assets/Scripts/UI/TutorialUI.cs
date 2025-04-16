using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Tutor : MonoBehaviour
{
    [SerializeField]private GameObject uiParent;
    [SerializeField] private TextMeshProUGUI upKeyText;
    [SerializeField] private TextMeshProUGUI downKeyText;
    [SerializeField] private TextMeshProUGUI leftKeyText;
    [SerializeField] private TextMeshProUGUI rightKeyText;
    [SerializeField] private TextMeshProUGUI interactKeyText;
    [SerializeField] private TextMeshProUGUI operateKeyText;
    [SerializeField] private TextMeshProUGUI pauseKeyText;

   
    private void Start()
    {
        GameMananger.instance.onStateChanged += GameManager_onStateChanged;
        Show();
    }

    private void GameManager_onStateChanged(object sender, System.EventArgs e)
    {
        if (GameMananger.instance.IsWaitingToStartState())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    private void Show()
    {
        UpdateVisual();
        uiParent.SetActive(true);
    }

    private void Hide()
    {
        uiParent.SetActive(false);
    }

    private void UpdateVisual()
    {
        upKeyText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Up);
        downKeyText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Down);
        leftKeyText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Left);
        rightKeyText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Right);
        interactKeyText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Interact);
        operateKeyText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Operate);
        pauseKeyText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Pause);

    }

}
