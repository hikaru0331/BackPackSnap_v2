using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text scoreText;

    public static int score = 0;
    public static int destroyCount = 0;

    //AnimationControllerの参照
    [SerializeField] private GameObject animationControllerObj;
    AnimationController animationController;

    // Start is called before the first frame update
    void Start()
    {
        animationController = animationControllerObj.GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    //通常歩行者に関するスコア
    public void ScoreIncresePedestrian()
    {
        animationController.PedestrianCut();

        score += 1000;
        destroyCount++;

        Destroy(GameManager.destroyEnemy, 1.0f);
    }
    public void ScoreDecresePedestrian()
    {
        score -= 1000;
        
        Destroy(GameManager.destroyEnemy);
    }

    //通常自転車に関するスコア
    public void ScoreIncreseCycle()
    {
        animationController.CycleCut();

        score += 5000;
        destroyCount++;

        Destroy(GameManager.destroyEnemy, 1.0f);
    }
    public void ScoreDecreseCycle()
    {
        score -= 5000;

        Destroy(GameManager.destroyEnemy);
    }

    //本革歩行者に関するスコア
    public void ScoreIncresePedestrianLeather()
    {
        animationController.PedestrianCut();

        score += 1000;
        destroyCount++;

        Destroy(GameManager.destroyEnemy, 1.0f);
    }
    public void ScoreDecresePedestrianLeather()
    {
        score -= 1000;

        Destroy(GameManager.destroyEnemy);
    }

    //本革自転車に関するスコア
    public void ScoreIncreseCycleLeather()
    {
        animationController.CycleCut();

        score += 5000;
        destroyCount++;

        Destroy(GameManager.destroyEnemy, 1.0f);
    }
    public void ScoreDecreseCycleLeather()
    {
        score -= 5000;

        Destroy(GameManager.destroyEnemy);
    }
}
