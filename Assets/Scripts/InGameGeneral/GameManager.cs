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
    //マウスクリックの視点と終点を入れる変数
    private Vector2 startPos;
    private Vector2 endPos;
    //マウスクリックの始点と終点の座標間の距離を入れる変数
    private float posDistance;

    [SerializeField] private GameObject animationControllerObj;
    AnimationController animationController;

    //破壊する通行人を入れる変数
    public static GameObject destroyEnemy;
    public static Rigidbody2D destroyRigidbody;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = scoreManagerObj.GetComponent<ScoreManager>();

        animationController = animationControllerObj.GetComponent<AnimationController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            startPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

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

                    destroyRigidbody = hit.collider.GetComponent<Rigidbody2D>();
                    destroyRigidbody.velocity = Vector2.zero;
                }
                                
                 if (hit.collider.tag == "Cycle")
                {
                    destroyEnemy = hit.collider.gameObject;

                    destroyRigidbody = hit.collider.GetComponent<Rigidbody2D>();
                    destroyRigidbody.velocity = Vector2.zero;
                }                
            }

        }

        if (Input.GetMouseButtonUp(0))
        {
            endPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            posDistance = Vector2.Distance(startPos, endPos);

            if (posDistance > 1.0f)
            {
                if (destroyEnemy != null)
                {
                    if (destroyEnemy.tag == "Pedestrian")
                    {                        
                        destroyRigidbody.velocity = Vector2.zero;

                        animationController.PedestrianCut();
                        scoreManager.ScoreIncresePedestrian();
                        //UltlaManager.歩行者分の必切技ゲージ加算のための関数();

                        destroyEnemy = null;
                    }
                    else if (destroyEnemy.tag == "Cycle")
                    {
                        destroyRigidbody.velocity = Vector2.zero;

                        animationController.CycleCut();
                        scoreManager.ScoreIncreseCycle();
                        //UltlaManager.歩行者分の必切技ゲージ加算のための関数();

                        destroyEnemy = null;
                    }
                }                               
            }

            //再びカットできるようにする
            isCut = !isCut;
        }
    }
}
