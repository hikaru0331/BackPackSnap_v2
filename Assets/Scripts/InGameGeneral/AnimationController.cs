using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator pedestrianAnimator;
    public Animator cycleAnimator;

    public Animator pedestrianLeatherAnimator;
    public Animator cycleLeatherAnimator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    //通常通行人のアニメーション変更
    public void PedestrianCut()
    {
        pedestrianAnimator = GameManager.destroyEnemy.GetComponent<Animator>();

        pedestrianAnimator.SetBool("isCut", true);
    }

    public void CycleCut()
    {
        cycleAnimator = GameManager.destroyEnemy.GetComponent<Animator>();

        cycleAnimator.SetBool("isCut", true);
    }

    //本革通行人のアニメーション変更
    public void PedestrianLeatherCut()
    {
        pedestrianLeatherAnimator = GameManager.destroyEnemy.GetComponent<Animator>();

        pedestrianLeatherAnimator.SetBool("isCut", true);
    }

    public void CycleLeatherCut()
    {
        cycleLeatherAnimator = GameManager.destroyEnemy.GetComponent<Animator>();

        cycleLeatherAnimator.SetBool("isCut", true);
    }
}
