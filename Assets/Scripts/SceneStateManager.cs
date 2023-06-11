using System.Collections;
using System.Collections.Generic;
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

    //以下OutGameに関するシーンをロードするメソッド
    public void LoadTitle()
    {
        SceneManager.LoadScene("Title");
    }

    public void LoadStageSelect()
    {
        SceneManager.LoadScene("StageSelection");
    }

    public void QuitGame()
    {
    #if UNITY_EDITOR
         UnityEditor.EditorApplication.isPlaying = false; //ゲームプレイ終了
    #else
         Application.Quit(); //ゲームプレイ終了
    #endif
    }


    //以下InGameシーンをロードするメソッド
    public void LoadRuralInGame()
    {
        //スコアなどを初期化する
        ScoreManager.score = 0;
        ScoreManager.destroyCount = 0;

        SceneManager.LoadScene("RuralInGame");
    }

    public void LoadArbanInGame()
    {
        //スコアなどを初期化する
        ScoreManager.score = 0;
        ScoreManager.destroyCount = 0;

        SceneManager.LoadScene("ArbanInGame");
    }


    //以下Resultシーンをロードするメソッド
    public void LoadRuralResult()
    {
        SceneManager.LoadScene("RuralResult");
    }

    public void LoadArbanResult()
    {
        SceneManager.LoadScene("ArbanResult");
    }
}
