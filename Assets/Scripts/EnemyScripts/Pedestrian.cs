using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    public float pedSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.up * pedSpeed * Time.deltaTime;
    }

    private void OnDestroy()
    {
        Debug.Log("歩行者分のスコアが減った！");
        //ScoreManager.歩行者分のスコア減らすための関数();
    }
}
