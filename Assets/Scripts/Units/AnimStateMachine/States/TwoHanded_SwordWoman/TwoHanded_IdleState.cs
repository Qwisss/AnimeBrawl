
using UnityEngine;

public class TwoHanded_IdleState : State
{
    public TwoHanded_IdleState(Animator anim) : base(anim)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter TwoHanded_IdleState");
        anim.StopPlayback();
        anim.CrossFade(animBase.TwoHanded_Idle, 0.5f);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit TwoHanded_IdleState");
        anim.StopPlayback();
    }


}
