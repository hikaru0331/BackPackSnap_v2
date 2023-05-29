using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{
    //歩行者のスピード
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

    public void PedstrianCut()
    {
        Debug.Log("通行人切断");
        //ScoreManager.歩行者分のスコア加算のための関数();
    }
}
