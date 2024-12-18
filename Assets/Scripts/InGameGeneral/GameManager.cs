using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    //ScoreManager????????
    [SerializeField] private GameObject scoreManagerObj;
    ScoreManager scoreManager;

    //AudioManager????????
    [SerializeField] private GameObject audioManagerObj;
    AudioManager audioManager;
    //??s?l?????????????????????????????
    private bool hasPlayed = false;

    //??s?l?????????????????????
    private bool isCut = false;
    //?}?E?X?N???b?N????_??I?_????????
    private Vector2 startPos;
    private Vector2 endPos;
    //?}?E?X?N???b?N??n?_??I?_????W??????????????
    [System.NonSerialized] public static float posDistance;

    //?j????s?l????????
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
                    //??f?????I?u?W?F?N?g??destroyEnemy????
                    destroyEnemy = hit.collider.gameObject;

                    //destroyEnemy??R???|?[?l???g???擾
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
                        //???????s?l???~??鏈??
                        destroyRigidbody.velocity = Vector2.zero;

                        scoreManager.ScoreIncresePedestrian();
                        //UltlaManager.???s?????K??Z?Q?[?W???Z????????();

                        //?j??A?j???[?V???????????????????????????
                        destroyCollider.enabled = false;

                        //?????????????
                        audioManager.PlayCutSound();
                        hasPlayed = true;

                        //?j????destroyEnemy????g????????
                        destroyEnemy = null;
                        destroyRigidbody = null;
                        destroyCollider = null;
                    }

                    else if (destroyEnemy.tag == "Cycle")
                    {
                        destroyRigidbody.velocity = Vector2.zero;
                                                
                        scoreManager.ScoreIncreseCycle();
                        //UltlaManager.???s?????K??Z?Q?[?W???Z????????();

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

                        //?_???[?W???????????O????A?j??鏈?????s??
                        if (destroyEnemy.name == "PedLeather_Damaged")
                        {
                            destroyRigidbody.velocity = Vector2.zero;

                            //UltlaManager.?{?v???s?????K??Z?Q?[?W???Z????????();

                            destroyCollider.enabled = false;
                        }

                        //??????f????A?_???[?W???????????O???X
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

                            //UltlaManager.?{?v???]?????K??Z?Q?[?W???Z????????();

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

            //??уJ?b?g???????????
            isCut = !isCut;
        }
    }
}
