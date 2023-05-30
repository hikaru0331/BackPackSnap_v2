using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cycle : MonoBehaviour
{
    //é©ì]é‘ÇÃÉXÉsÅ[Éh
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
        Debug.Log("é©ì]é‘êÿíf");
    }
}
