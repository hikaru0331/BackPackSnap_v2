using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pedestrian : MonoBehaviour
{   
    //歩行者のスピード
    public static float pedSpeed = 3.0f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, pedSpeed);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
    }

    public void PedestrianCut()
    {
        //ここでアニメーションを制御するメソッドを呼び出す
    }
}
