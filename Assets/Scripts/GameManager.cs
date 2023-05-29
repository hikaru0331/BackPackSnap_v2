using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemies;

    Pedestrian pedestrian;
    Cycle cycle;

    // Start is called before the first frame update
    void Start()
    {
        pedestrian = enemies[0].GetComponent<Pedestrian>();
        cycle = enemies[1].GetComponent<Cycle>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit)
            {
                if (hit.collider.tag == "Pedestrian")
                {
                    pedestrian.PedstrianCut();
                }
                                
                 if (hit.collider.tag == "Cycle")
                {
                    cycle.CycleCut();
                }
                
            }

        }
    }
}
