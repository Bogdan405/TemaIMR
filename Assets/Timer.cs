using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timeSink;
    private float timeRemaining;
    public bool isRunning;

    private void Start()
    {
        timeRemaining = timeSink;
        isRunning = false;
    }

    void Update()
    {
        if (isRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
            }
            else
            {
                timeRemaining = 0;
                isRunning = false;
            }
        }
    }

    public void RestartTimer()
    {
        timeRemaining = timeSink;
        isRunning = true;
    }
}
