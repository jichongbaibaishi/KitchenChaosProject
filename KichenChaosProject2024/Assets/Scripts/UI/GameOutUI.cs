using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOutUI : MonoBehaviour
{
    [SerializeField]private GameObject uiParent;
    [SerializeField] private TextMeshProUGUI numberTextUI;
    void Start()
    {
        Hide();
        GameMananger.instance.onStateChanged += GameManager_onStateChanged;
    }

    private void GameManager_onStateChanged(object sender, System.EventArgs e)
    {
        if (GameMananger.instance.IsGameOut())
        {
            Show();
        }
    }
    
    void Update()
    {
        
    }
    private void Show()
    {
        numberTextUI.text =OrderMananger.Instance.GetRecipeCount().ToString();
        gameObject.SetActive(true);
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
