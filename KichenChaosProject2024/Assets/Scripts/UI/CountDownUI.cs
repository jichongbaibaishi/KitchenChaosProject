using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    [SerializeField]private TextMeshProUGUI nunberText;
    private void Start()
    {
        GameMananger.instance.onStateChanged += GameMananger_onStateChanged;
    }
    private void Update()
    {
        if (GameMananger.instance.IsCountDownstate())
        {
            nunberText.text = Mathf.CeilToInt (GameMananger.instance.GetCountDownTimer()).ToString();
        }
    }
    private void GameMananger_onStateChanged(object sender, System.EventArgs e)
    {
        if (GameMananger.instance.IsCountDownstate())
        {
            nunberText.gameObject
                .SetActive(true);
        }else
        {
            nunberText.gameObject .SetActive(false);
        }
    }
}
