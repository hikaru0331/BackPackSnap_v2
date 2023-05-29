using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //通行人を切ったかどうか判定する変数
    private bool isCut = false;

    //通行人を入れるための配列
    public GameObject[] enemies;

    //通行人のクラスを参照するための変数
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
        if(Input.GetMouseButton(0)) 
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast((Vector2)ray.origin, (Vector2)ray.direction);

            if (hit && !isCut)
            {
                isCut = !isCut;

                if (hit.collider.tag == "Pedestrian")
                {
                    pedestrian.PedstrianCut();
                    Destroy(hit.collider.gameObject);
                }
                                
                 if (hit.collider.tag == "Cycle")
                {
                    cycle.CycleCut();
                    Destroy(hit.collider.gameObject);
                }
                
            }

        }

        if(Input.GetMouseButtonUp(0))
        {
            isCut = !isCut;
        }

    }
}
