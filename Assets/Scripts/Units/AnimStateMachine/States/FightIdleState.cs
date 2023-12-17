using UnityEngine;

public class FightIdleState : State
{
    public FightIdleState(Animator anim) : base(anim)
    {

    }


    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter FightIdleState");
        anim.StopPlayback();
        anim.CrossFade(animBase.FightIdle, 0.1f);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit FightIdleState");
        anim.StopPlayback();
    }
}
