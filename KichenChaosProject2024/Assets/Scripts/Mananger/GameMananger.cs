using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMananger : MonoBehaviour
{
    private enum State
    {
        WaitingToStart,
        CountDownToStart,
        GamePlaaying,
        GameOver
    }
    private State state;
    private float waitingtostarttimer = 1;
    //private float waitingtostoptimer = 1;
    private float waitingtowaittimer = 3;
    private float gameplayingtomer= 10;
    private void Awake()
    {
        state = State.WaitingToStart;
    }
    // Start is called before the first frame update
    
    // Update is called once per frame
    void Update()
    {
        switch (state)
        {


            case State.WaitingToStart:
                waitingtostarttimer-=(Time.time);
                if( waitingtostarttimer<=0)
                {
                    TurntoCountdownToStart();
                }
                break;
            case State.CountDownToStart:
                waitingtowaittimer-=(Time.time);
                if (waitingtowaittimer <= 0)
                {
                    TurntoGamePlaying();
                }
                break;
            case State.GamePlaaying:
                gameplayingtomer-= Time.time;
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
    //转换到倒计时的状态
    private void TurntoCountdownToStart() {

        state = State.CountDownToStart;
    }
    private void TurntoGamePlaying()
    {
        state = State.GamePlaaying;  
    }
    private void TurntoGameOver()
    {
        state=State.GameOver;
    }
}
