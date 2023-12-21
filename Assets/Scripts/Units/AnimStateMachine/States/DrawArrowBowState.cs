using UnityEngine;

public class DrawArrowBowState : State
{
    public DrawArrowBowState(Animator anim) : base(anim)
    {

    }


    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter DrawArrowBowState");
        anim.StopPlayback();
        anim.CrossFade(animBase.DrawArrowBow, 0.1f);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit DrawArrowBowState");
        anim.StopPlayback();
    }
}
