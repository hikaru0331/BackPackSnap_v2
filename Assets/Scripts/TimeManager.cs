using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.EventSystems.EventTrigger;

public class TimeManager : MonoBehaviour
{
    public Text timerText;
    private float timeCounter = 60.0f;

    public GameObject playingCanvas;
    public GameObject gameOverCanvas;


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

            //タグの付いたオブジェクトをそれぞれ配列に代入
            GameObject[] pedestrians = GameObject.FindGameObjectsWithTag("Pedestrian");
            GameObject[] cycles = GameObject.FindGameObjectsWithTag("Cycle");

            //配列enemyに入ったオブジェクトをすべて破壊するまで繰り返す処理
            foreach (GameObject enemies in pedestrians)
            {
                Destroy(enemies);
            }
            foreach(GameObject enemies in cycles)
            {
                Destroy(enemies);
            }

            //UIの切り替え処理
            playingCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);

        }
    }
}
