using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float TimeLeft;
    public bool TimerOn=false;
    public TextMeshProUGUI timerText;
    private void Start() {
        TimerOn=true;
    }
    private void Update() {
        if(TimerOn){
            if(TimeLeft>0){
                TimeLeft-=Time.deltaTime;
                timerText.text=TimeLeft.ToString("0");
        }
        else{
            TimerOn=false;
            GameManager.instance.GameOver();
        }
        
    }
}
}
