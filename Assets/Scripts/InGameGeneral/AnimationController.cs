using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator pedestrianAnimator;
    public Animator cycleAnimator;

    public Animator pedestrianLeatherAnimator;
    public Animator cycleLeatherAnimator;

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

        pedestrianLeatherAnimator.SetBool ("isCut1", true);

        if (GameManager.destroyEnemy.name == "PedLeather_Damaged")
        {
            pedestrianLeatherAnimator.SetBool("isCut2", true);
        }
    }

    public void CycleLeatherCut()
    {
        cycleLeatherAnimator = GameManager.destroyEnemy.GetComponent<Animator>();

        cycleLeatherAnimator.SetBool("isCut1", true);

        if (GameManager.destroyEnemy.name == "CycleLeather_Damaged")
        {
            cycleLeatherAnimator.SetBool("isCut2", true);
        }
    }
}
