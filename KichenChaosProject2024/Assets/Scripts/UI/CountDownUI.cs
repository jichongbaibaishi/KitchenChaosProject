using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountDownUI : MonoBehaviour
{
    private const string IS_SHAKE = "Is_Shake";
    [SerializeField]private TextMeshProUGUI nunberText;
    private Animator animator;
    private int preNumber = -1;
    private void Start()
    {
        animator = GetComponent<Animator>();
        GameMananger.instance.onStateChanged += GameMananger_onStateChanged;
    }
    private void Update()
    {
        if (GameMananger.instance.IsCountDownstate())
        {
            int nowNumber=Mathf.CeilToInt(GameMananger.instance.GetCountDownTimer());
           
            nunberText.text = Mathf.CeilToInt (GameMananger.instance.GetCountDownTimer()).ToString();
            if (nowNumber != preNumber)
            {
                preNumber = nowNumber;
                animator.SetTrigger(IS_SHAKE);
                SoundManager.instance.playCountDownSound();
            }
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
