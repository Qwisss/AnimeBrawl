using UnityEngine;

public class RunState : State
{
    public RunState(Animator anim) : base(anim)
    {

    }


    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter RunState");
        anim.StopPlayback();
        anim.CrossFade(animBase.Run, 0.1f);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit RunState");
        anim.StopPlayback();
    }

    public override void Update()
    {
        base.Update();

    }
}
