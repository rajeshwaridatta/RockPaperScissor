using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    private float timeRemaining = 1;
    private float maxTime = 1f;
    public bool timerIsRunning = false;
    
    public delegate void OnTimerOver();
    public static event OnTimerOver onTimerOver;
    public void DoOnTimerOver()
    {
        if (onTimerOver != null)
        {
            onTimerOver();
        }
    }
    void Update()
    {
        if (timerIsRunning )
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                float progress = timeRemaining / maxTime;
                GamePlayController.Instance.uiController.SetTimerUI(progress, maxTime);
            } else
            {
                timeRemaining = 1;
                timerIsRunning = false;
                GamePlayController.Instance.uiController.ResetTimerUI();
                DoOnTimerOver();
            }           
        }
    }
}
