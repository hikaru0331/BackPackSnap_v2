using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad (gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }


    //以下InGameシーンをロードするメソッド
    public void LoadRuralInGame()
    {
        //スコアなどを初期化する
        ScoreManager.score = 0;
        ScoreManager.destroyCount = 0;

        SceneManager.LoadScene("RuralInGame");
    }


    //以下Resultシーンをロードするメソッド
    public void LoadRuralResult()
    {
        SceneManager.LoadScene("RuralResult");
    }
}
