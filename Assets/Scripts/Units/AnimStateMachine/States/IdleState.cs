using UnityEngine;

public class IdleState : State
{

    public IdleState(Animator anim) : base(anim) 
    { 
    
    }


    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter IdleState");
        anim.StopPlayback();
        anim.CrossFade(animBase.Idle, 0.1f);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit IdleState");
        anim.StopPlayback();
    }
}
