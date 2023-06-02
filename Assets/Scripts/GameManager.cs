using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    //ScoreManagerを入れる変数
    [SerializeField] private GameObject scoreManagerObj;
    ScoreManager scoreManager;

    //通行人を切ったかどうか判定する変数
    private bool isCut = false;

    //通行人を入れるための配列
    public GameObject[] enemies;

    //通行人のクラスを参照するための変数
    Pedestrian pedestrian;
    Cycle cycle;

    //破壊する通行人を入れる変数
    public static GameObject destroyEnemy;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = scoreManagerObj.GetComponent<ScoreManager>();

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
                    destroyEnemy = hit.collider.gameObject;

                    pedestrian.PedstrianCut();
                    scoreManager.ScoreIncresePedestrian();
                    //UltlaManager.歩行者分の必切技ゲージ加算のための関数();
                }
                                
                 if (hit.collider.tag == "Cycle")
                {
                    destroyEnemy = hit.collider.gameObject;

                    cycle.CycleCut();
                    scoreManager.ScoreIncreseCycle();
                    //UltlaManager.自転車分の必切技ゲージ加算のための関数();
                }
                
            }

        }

        if(Input.GetMouseButtonUp(0))
        {
            isCut = !isCut;
        }

    }
}
