using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CycleLeather : MonoBehaviour
{
    //自転車のスピード
    private float cycleSpeed = 4.0f;

    [System.NonSerialized] public static int cycleLeatherHP = 2;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, cycleSpeed);
    }    
}
