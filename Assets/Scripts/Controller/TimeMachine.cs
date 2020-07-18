using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class TimeMachine : MonoBehaviour
{
    /// <summary>
    /// 60 second is a one day
    /// </summary>
    private static TimeMachine instance;

    public static TimeMachine Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new TimeMachine();
            }
            return instance;
        }
    }

    float deltaTime;

    int day;

    bool startTime = false;

    public void SetTimeMachine(Character character)
    {
        day = character.deltaDay;
        deltaTime = 0;
    }


    private void Update()
    {
        if (startTime == true)
        {
            deltaTime += Time.deltaTime;

            if (deltaTime > 120)
            {
                IncreaseDay();
                deltaTime = 0;
            }
        }
    }

    public void StopTime()
    {
        startTime = false;
    }

    void IncreaseDay()
    {
        day++;
    }
}
