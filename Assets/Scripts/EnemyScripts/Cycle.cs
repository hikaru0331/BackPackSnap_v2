using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    //自転車のスピード
    public static float cycleSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position += Vector3.up * cycleSpeed * Time.deltaTime;
    }

    public void CycleCut()
    {
        //ここでアニメーションを制御するメソッドを呼び出す
    }
}
