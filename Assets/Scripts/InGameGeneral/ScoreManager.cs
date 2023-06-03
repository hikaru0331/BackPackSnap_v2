using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    public static int score = 0;
    public static int destroyCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    public void ScoreIncresePedestrian()
    {
        score += 1000;
        destroyCount++;

        Destroy(GameManager.destroyEnemy);
    }
    public void ScoreDecresePedestrian()
    {
        score -= 1000;
        
        Destroy(GameManager.destroyEnemy);
    }

    public void ScoreIncreseCycle()
    {
        score += 5000;
        destroyCount++;

        Destroy(GameManager.destroyEnemy);
    }
    public void ScoreDecreseCycle()
    {
        score -= 5000;

        Destroy(GameManager.destroyEnemy);
    }
}
