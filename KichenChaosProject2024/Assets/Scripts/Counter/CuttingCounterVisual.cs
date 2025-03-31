using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounterVisual : MonoBehaviour
{
    private const string Cut="Cut";
    private Animator anim;
    public void Start()
    {
        anim = GetComponentInChildren<Animator>();
    }
    public void PlayCut()
    {
        anim.SetTrigger(Cut);
    }
}
