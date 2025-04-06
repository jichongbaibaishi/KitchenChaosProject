using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSound : MonoBehaviour
{
    private Player player;
    private float stepSoundRate= .13f;
    private float stepTimer = 0;
    private void Start()
    {
        player=GetComponent<Player>(); 
    }
    public void Update()
    {

        stepTimer += Time.deltaTime;
        if (stepTimer > stepSoundRate)
        {
            

            stepTimer=0;
            if (player.IsWalking)
            {
                float voice = .1f;
                SoundManager.instance.PlayerSound(voice);
            }
           
        }
    }
}
