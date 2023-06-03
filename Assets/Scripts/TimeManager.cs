using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text timerText;
    private float timeCounter = 60.0f;
    

    // Start is called before the first frame update
    void Start()
    {
                
    }

    // Update is called once per frame
    void Update()
    {
        timeCounter -= Time.deltaTime;

        timerText.text = "Time: " + timeCounter.ToString("f2");

        if (timeCounter <= 0.0f)
        {
            timeCounter = 0.0f;
        }
    }
}
