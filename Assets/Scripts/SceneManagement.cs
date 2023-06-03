using System.Collections;
using System.Collections.Generic;
using UnityEditor.EditorTools;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateManager : MonoBehaviour
{
    public static SceneStateManager instance;

    // Start is called before the first frame update
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    //Titleをロードするメソッド
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
