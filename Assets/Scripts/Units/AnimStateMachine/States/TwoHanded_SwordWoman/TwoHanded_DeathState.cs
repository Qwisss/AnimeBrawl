using UnityEngine;

public class TwoHanded_DeathState : State
{
    public TwoHanded_DeathState(Animator anim) : base(anim)
    {

    }

    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter TwoHanded_DeathState");
        anim.StopPlayback();
        anim.CrossFade(animBase.TwoHanded_Death, 0.1f);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit TwoHanded_DeathState");
        anim.StopPlayback();
    }

}
