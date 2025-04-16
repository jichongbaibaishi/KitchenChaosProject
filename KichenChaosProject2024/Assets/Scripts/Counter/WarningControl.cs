using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WarningControl : MonoBehaviour
{
    private const string IS_FLICKER = "IsFlicker";

    [SerializeField]private GameObject warningUI;
    [SerializeField] private Animator progressBarAnimator;

    private bool isWarning = false;
    private float warningSoundRate = .2f;
    private float warningSoundTimer = 0;

    private void Update()
    {
        if (isWarning)
        {
            warningSoundTimer += Time.deltaTime;
            if (warningSoundTimer > warningSoundRate)
            {
                warningSoundTimer = 0;
                SoundManager.instance.PlayWarningSound();
            }
        }
    }

    public void ShowWarning()
    {
        if (isWarning == false)
        {
            isWarning = true;
            warningUI.SetActive(true);
            progressBarAnimator.SetBool(IS_FLICKER, true);
        }
    }

    public void StopWarning()
    {
        isWarning = false;
        warningUI.SetActive(false);
        progressBarAnimator.SetBool(IS_FLICKER, false);
    }
    
}
