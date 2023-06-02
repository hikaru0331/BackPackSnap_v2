using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyGenerator : MonoBehaviour
{
    //ScoreManagerを入れる変数
    [SerializeField] private GameObject scoreManagerObj;
    ScoreManager scoreManager;

    //通行人参照用変数
    [SerializeField] private GameObject pedestrian;
    [SerializeField] private GameObject cycle;

    //各通行人専用のタイマー
    private float pedTimer;
    private float cycleTimer;

    //通行人ごとのインターバルの変数
    private float pedInterval;
    private float cycleInterval;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = scoreManagerObj.GetComponent<ScoreManager>();
    }

    // Update is called once per frame
    void Update()
    {
        pedTimer += Time.deltaTime;
        cycleTimer += Time.deltaTime;

        float position = Random.Range(-3.0f, 3.0f);

        pedInterval = Random.Range(1.0f, 2.0f);
        cycleInterval = Random.Range(3.0f, 5.0f);

        //pedInterval = 1.0f;
        //cycleInterval = 5.0f;

        if (pedTimer >= pedInterval)
        {
            pedTimer = 0;

            Instantiate(pedestrian, new Vector3(position, -6.5f, 0), Quaternion.identity);

        }

        if (cycleTimer >= cycleInterval)
        {
            cycleTimer = 0;

            Instantiate(cycle, new Vector3(position, -6.5f, 0), Quaternion.identity);

        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Pedestrian")
        {
            GameManager.destroyEnemy = other.gameObject; 
            scoreManager.ScoreDecresePedestrian();
        }

        if (other.gameObject.tag == "Cycle")
        {
            GameManager.destroyEnemy = other.gameObject;
            scoreManager.ScoreDecreseCycle();
        }
    }

}
