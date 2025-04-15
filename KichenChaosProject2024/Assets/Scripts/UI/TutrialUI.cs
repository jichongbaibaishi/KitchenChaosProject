using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutrialUI : MonoBehaviour
{
    [SerializeField] private GameObject uiParent;

    [SerializeField] private TextMeshProUGUI upKeyButtonText;
    [SerializeField] private TextMeshProUGUI downKeyButtonText;
    [SerializeField] private TextMeshProUGUI leftKeyButtonText;
    [SerializeField] private TextMeshProUGUI rightKeyButtonText;
    [SerializeField] private TextMeshProUGUI interactKeyButtonText;
    [SerializeField] private TextMeshProUGUI operateKeyButtonText;
    [SerializeField] private TextMeshProUGUI pauseKeyButtonText;
    private void Start()
    {
        GameMananger.instance.onStateChanged += GameManager_onStateChanged;
        Show();
    }

    private void GameManager_onStateChanged(object sender, System.EventArgs e)
    {
        if(GameMananger.instance.IsWaitingToStartState())
        {
            Show();
        }
        else
        {
            Hide();
        }
    }

    // Start is called before the first frame update

    // Update is called once per frame
    private void UpdateVisual()
    {
        upKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Up);
        downKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Down);
        leftKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Left);
        rightKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Right);
        interactKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Interact);
        operateKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Operate);
        pauseKeyButtonText.text = GameInput.instance.GetBindingDisplayString(GameInput.BindingType.Pause);
    }
    private void Show()
    {
        uiParent.SetActive(true);
    }
    private void Hide() {
        uiParent.SetActive(false);
    }
}
