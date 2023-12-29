using UnityEngine;

public class TwoHanded_AttackState : State
{
    public TwoHanded_AttackState(Animator anim) : base(anim)
    {

    }


    public override void Enter()
    {
        base.Enter();
        Debug.Log("Enter TwoHanded_AttackState");
        anim.StopPlayback();
        anim.CrossFade(animBase.TwoHanded_Attack, 0.1f);
    }

    public override void Exit()
    {
        base.Exit();
        Debug.Log("Exit TwoHanded_AttackState");
        anim.StopPlayback();
    }

    public override void Update()
    {
        base.Update();

    }


}
