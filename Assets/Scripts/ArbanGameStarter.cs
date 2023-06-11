using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbanGameStarter : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject playingCanvas;

    public GameObject gameManager;
    public GameObject enemyGenerator;
    public GameObject scoreManager;
    public GameObject timeManager;
    public GameObject mouseEffectManager;
    public GameObject road;

    // Start is called before the first frame update
    void Start()
    {
        EnemyGenerator.pedRange = 1.0f;
        EnemyGenerator.cycleRange = 3.0f;

        EnemyGenerator.pedLeatherRange = 1.0f;
        EnemyGenerator.cycleLeatherRange = 3.0f;

        TimeManager.defaultTimeCounter = 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            startCanvas.SetActive(false);
            playingCanvas.SetActive(true);

            gameManager.SetActive(true);
            enemyGenerator.SetActive(true);
            scoreManager.SetActive(true);
            timeManager.SetActive(true);
            mouseEffectManager.SetActive(true);
            road.SetActive(true);
        }
    }

}
