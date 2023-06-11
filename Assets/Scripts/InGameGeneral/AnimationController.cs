using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator pedestrianAnimator;
    public Animator cycleAnimator;

    public Animator pedestrianLeatherAnimator;
    public Animator cycleLeatherAnimator;

    private int pedLeatherCutCount = 0;
    private int cycleLeatherCutCount = 0;

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

        pedLeatherCutCount++;
        pedestrianLeatherAnimator.SetInteger("cutCount", pedLeatherCutCount);

        if (pedLeatherCutCount >= 2)
        {
            pedLeatherCutCount = 0;
        }
    }

    public void CycleLeatherCut()
    {
        cycleLeatherAnimator = GameManager.destroyEnemy.GetComponent<Animator>();

        cycleLeatherCutCount++;
        cycleLeatherAnimator.SetInteger("cutCount", cycleLeatherCutCount);

        if (cycleLeatherCutCount >= 2)
        {
            cycleLeatherCutCount = 0;
        }
    }
}
