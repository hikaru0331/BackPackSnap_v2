using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianLeather : MonoBehaviour
{   
    //歩行者のスピード
    private float pedSpeed = 3.0f;

    [System.NonSerialized] public static int pedLeatherHP = 2;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0, pedSpeed);
    }
}
