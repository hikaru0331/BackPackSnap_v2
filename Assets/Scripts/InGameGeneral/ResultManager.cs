using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResultManager : MonoBehaviour
{
    public Text scoreResultText;
    public Text enemyResultText;

    // Start is called before the first frame update
    void Start()
    {
        scoreResultText.text = "スコア: " + ScoreManager.score.ToString();
        enemyResultText.text = "切ったリュック: " + ScoreManager.destroyCount.ToString() + "個";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
