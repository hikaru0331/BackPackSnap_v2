using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] private GameObject pedestrian;

    private float timer;
    public float interval;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        float position = Random.Range(-3, 3);

        if (timer >= interval)
        {
            timer = 0;

            Instantiate(pedestrian, new Vector3(position, -6.5f, 0), Quaternion.identity);

        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Pedestrian")
        {
            Destroy(other.gameObject);
            //ScoreManager.歩行者分のスコア減らすための関数();
        }
    }

}
