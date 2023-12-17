using UnityEngine;

public class HightKickState : State
{
    public HightKickState(Animator anim) : base(anim)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter HightKickState");
        anim.StopPlayback();
        anim.CrossFade(animBase.HightKick, 0.1f);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit HightKickState");
        anim.StopPlayback();
    }
}
