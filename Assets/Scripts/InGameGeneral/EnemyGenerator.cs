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

    //通行人ごとのインターバルの範囲を入れる変数
    public static float pedRange;
    public static float cycleRange;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = scoreManagerObj.GetComponent<ScoreManager>();

        pedInterval = Random.Range(pedRange, 2 * pedRange);
        cycleInterval = Random.Range(cycleRange, 2 * cycleRange);
    }

    // Update is called once per frame
    void Update()
    {
        pedTimer += Time.deltaTime;
        cycleTimer += Time.deltaTime;

        float position = Random.Range(-3.0f, 3.0f);

        if (pedTimer >= pedInterval)
        {
            pedTimer = 0;

            Instantiate(pedestrian, new Vector3(position, -6.5f, 0), Quaternion.identity);

            pedInterval = Random.Range(pedRange, 2.0f * pedRange);
        }

        if (cycleTimer >= cycleInterval)
        {
            cycleTimer = 0;

            Instantiate(cycle, new Vector3(position, -6.5f, 0), Quaternion.identity);

            cycleInterval = Random.Range(cycleRange, 1.5f * cycleRange);
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

    public void SetInterval()
    {
        pedRange /= 2.0f;
        cycleRange /= 2.0f;
    }

}
