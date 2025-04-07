using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananger : MonoBehaviour
{
    public static GameMananger instance {  get; private set; }
    private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaaying,
        GameOver
    }
    public event EventHandler onStateChanged;
    private State state;
    [SerializeField]private Player player;
    private float waitingtostarttimer = 1;
    //private float waitingtostoptimer = 1;
    private float countdowntostart = 3;
    private float gameplayingtomer= 10;
    private void Awake()
    {
        instance = this;
        TurntoWaitingToStart();
    }
   
    void Update()
    {
        switch (state)
        {


            case State.WaitingToStart:
                waitingtostarttimer-=Time.deltaTime;
                if( waitingtostarttimer<=0)
                {
                    
                    TurntoCountdownToStart();
                }
                break;
            case State.CountDownToStart:
                countdowntostart-= Time.deltaTime;
                if (countdowntostart <= 0)
                {
                    TurntoGamePlaying();
                }
                break;
            case State.GamePlaaying:
                gameplayingtomer-= Time.deltaTime;
                if( gameplayingtomer<=0)
                {
                    TurntoGameOver();
                }
                break;
            case State.GameOver:
                break;
            default:
                break;
        }
    }
    //转换到  的状态
    private void TurntoCountdownToStart() {
       

        state = State.CountDownToStart;
        DisablePlayer();
        onStateChanged?.Invoke(this,EventArgs.Empty);
    }
    private void TurntoGamePlaying()
    {
        state = State.GamePlaaying;  
        EnablePlayer(); onStateChanged?.Invoke(this, EventArgs.Empty);
    }
    private void TurntoGameOver()
    {
        state=State.GameOver;
        onStateChanged?.Invoke(this, EventArgs.Empty);
    }
    private void TurntoWaitingToStart()
    {
        state = State.WaitingToStart;
        DisablePlayer() ; onStateChanged?.Invoke(this, EventArgs.Empty);
    }
    //角色移动控制
    private void DisablePlayer()
    {
        player.enabled = false;
    }
    private void EnablePlayer()
    {
        player.enabled=true;
    }
    public bool IsCountDownstate()
    {
        return state == State.CountDownToStart;
    }
    public bool IsGamePlayingState()
    {
        return state == State.GamePlaaying;
    }
    public float GetCountDownTimer()
    {
        return countdowntostart;
    }
}
