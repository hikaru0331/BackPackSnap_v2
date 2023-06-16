using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //ScoreManagerを入れる変数
    [SerializeField] private GameObject scoreManagerObj;
    ScoreManager scoreManager;

    //AudioManagerを入れる変数
    [SerializeField] private GameObject audioManagerObj;
    AudioManager audioManager;
    //通行人を切ったかどうかで効果音を分けるための変数
    private bool hasPlayed = false;

    //通行人を切ったかどうか判定する変数
    private bool isCut = false;
    //マウスクリックの視点と終点を入れる変数
    private Vector2 startPos;
    private Vector2 endPos;
    //マウスクリックの始点と終点の座標間の距離を入れる変数
    private float posDistance;

    //破壊する通行人を入れる変数
    public static GameObject destroyEnemy;
    private Rigidbody2D destroyRigidbody;
    private BoxCollider2D destroyCollider;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = scoreManagerObj.GetComponent<ScoreManager>();
        audioManager = audioManagerObj.GetComponent<AudioManager>();
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
                    //切断したオブジェクトをdestroyEnemyに保存
                    destroyEnemy = hit.collider.gameObject;

                    //destroyEnemyのコンポーネントを取得
                    destroyRigidbody = hit.collider.GetComponent<Rigidbody2D>();
                    destroyCollider = hit.collider.GetComponent<BoxCollider2D>();                    
                }
                                
                else if (hit.collider.tag == "Cycle")
                {
                    destroyEnemy = hit.collider.gameObject;

                    destroyRigidbody = hit.collider.GetComponent<Rigidbody2D>();

                    destroyCollider = hit.collider.GetComponent<BoxCollider2D>();
                }

                else if (hit.collider.tag == "PedestrianLeather")
                {
                    destroyEnemy = hit.collider.gameObject;

                    destroyRigidbody = hit.collider.GetComponent<Rigidbody2D>();

                    destroyCollider = hit.collider.GetComponent<BoxCollider2D>();
                }

                else if (hit.collider.tag == "CycleLeather")
                {
                    destroyEnemy = hit.collider.gameObject;

                    destroyRigidbody = hit.collider.GetComponent<Rigidbody2D>();

                    destroyCollider = hit.collider.GetComponent<BoxCollider2D>();
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
                        //切った通行人を止める処理
                        destroyRigidbody.velocity = Vector2.zero;

                        scoreManager.ScoreIncresePedestrian();
                        //UltlaManager.歩行者分の必切技ゲージ加算のための関数();

                        //破壊アニメーション再生時に当たり判定を消す処理
                        destroyCollider.enabled = false;

                        //効果音を鳴らす処理
                        audioManager.PlayCutSound();
                        hasPlayed = true;

                        //破壊後にdestroyEnemyの中身を削除する
                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }

                    else if (destroyEnemy.tag == "Cycle")
                    {
                        destroyRigidbody.velocity = Vector2.zero;
                                                
                        scoreManager.ScoreIncreseCycle();
                        //UltlaManager.歩行者分の必切技ゲージ加算のための関数();

                        destroyCollider.enabled = false;

                        audioManager.PlayCutSound();
                        hasPlayed = true;

                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }

                    else if (destroyEnemy.tag == "PedestrianLeather")
                    {
                        scoreManager.ScoreIncresePedestrianLeather();

                        //ダメージを受けた状態の名前ならば、破壊する処理を行う
                        if (destroyEnemy.name == "PedLeather_Damaged")
                        {
                            destroyRigidbody.velocity = Vector2.zero;

                            //UltlaManager.本革歩行者分の必切技ゲージ加算のための関数();

                            destroyCollider.enabled = false;
                        }

                        //一回目の切断ならば、ダメージを受けた状態の名前に変更
                        if (destroyEnemy.name == "PedestrianLeather(Clone)")
                        {
                            destroyEnemy.name = "PedLeather_Damaged";
                        }

                        audioManager.PlayCutSound();
                        hasPlayed = true;

                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }

                    else if (destroyEnemy.tag == "CycleLeather")
                    {
                        scoreManager.ScoreIncreseCycleLeather();

                        if (destroyEnemy.name == "CycleLeather_Damaged")
                        {
                            destroyRigidbody.velocity = Vector2.zero;

                            //UltlaManager.本革自転車分の必切技ゲージ加算のための関数();

                            destroyCollider.enabled = false;
                        }

                        if (destroyEnemy.name == "CycleLeather(Clone)")
                        {
                            destroyEnemy.name = "CycleLeather_Damaged";
                        }

                        audioManager.PlayCutSound();
                        hasPlayed = true;

                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }
                }                               
            }

            if (!hasPlayed)
            {
                audioManager.PlayCutSound();
            }

            hasPlayed = false;

            //再びカットできるようにする
            isCut = !isCut;
        }
    }
}
