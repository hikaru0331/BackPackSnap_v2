using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyGenerator : MonoBehaviour
{
    //ScoreManager������ϐ�
    [SerializeField] private GameObject scoreManagerObj;
    ScoreManager scoreManager;

    //�ʍs�l�Q�Ɨp�ϐ�
    [SerializeField] private GameObject pedestrian;
    [SerializeField] private GameObject cycle;
    [SerializeField] private GameObject pedestrianLeather;
    [SerializeField] private GameObject cycleLeather;

    //�e�ʍs�l��p�̃^�C�}�[
    private float pedTimer;
    private float cycleTimer;
    private float pedLeatherTimer;
    private float cycleLeatherTimer;

    //�ʍs�l���Ƃ̃C���^�[�o���̕ϐ�
    private float pedInterval;
    private float cycleInterval;
    private float pedLeatherInterval;
    private float cycleLeatherInterval;

    //�ʍs�l���Ƃ̃C���^�[�o���͈̔͂�����ϐ�
    public static float pedRange;
    public static float cycleRange;
    public static float pedLeatherRange;
    public static float cycleLeatherRange;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = scoreManagerObj.GetComponent<ScoreManager>();

        pedInterval = Random.Range(pedRange, 2 * pedRange);
        cycleInterval = Random.Range(cycleRange, 2 * cycleRange);

        pedLeatherInterval = Random.Range(pedLeatherRange, 2 * pedLeatherRange);
        cycleLeatherInterval = Random.Range(cycleLeatherRange, 2 * cycleLeatherRange);
    }

    // Update is called once per frame
    void Update()
    {
        pedTimer += Time.deltaTime;
        cycleTimer += Time.deltaTime;
        pedLeatherTimer += Time.deltaTime;
        cycleLeatherTimer += Time.deltaTime;

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

        if (pedLeatherTimer >= pedLeatherInterval)
        {
            pedLeatherTimer = 0;

            Instantiate(pedestrianLeather, new Vector3(position, -6.5f, 0), Quaternion.identity);

            pedLeatherInterval = Random.Range(pedLeatherRange, 2.0f * pedLeatherRange);
        }

        if (cycleLeatherTimer >= cycleLeatherInterval)
        {
            cycleLeatherTimer = 0;

            Instantiate(cycleLeather, new Vector3(position, -6.5f, 0), Quaternion.identity);

            cycleLeatherInterval = Random.Range(cycleLeatherRange, 1.5f * cycleLeatherRange);
        }

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Pedestrian")
        {
            GameManager.destroyEnemy = other.gameObject;
            scoreManager.ScoreDecresePedestrian();

            GameManager.destroyEnemy = null;
        }

        if (other.gameObject.tag == "Cycle")
        {
            GameManager.destroyEnemy = other.gameObject;
            scoreManager.ScoreDecreseCycle();

            GameManager.destroyEnemy = null;
        }

        if (other.gameObject.tag == "PedestrianLeather")
        {
            GameManager.destroyEnemy = other.gameObject;
            scoreManager.ScoreDecresePedestrianLeather();

            GameManager.destroyEnemy = null;
        }

        if (other.gameObject.tag == "CycleLeather")
        {
            GameManager.destroyEnemy = other.gameObject;
            scoreManager.ScoreDecreseCycleLeather();

            GameManager.destroyEnemy = null;
        }
    }

    public void SetInterval()
    {
        pedRange /= 2.0f;
        cycleRange /= 2.0f;
        pedLeatherRange /= 2.0f;
        cycleLeatherRange /= 2.0f;
    }

}
