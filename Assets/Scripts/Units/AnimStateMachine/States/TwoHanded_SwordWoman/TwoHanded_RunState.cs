using Unity.VisualScripting;
using UnityEngine;

public class TwoHanded_RunState : State
{
    public TwoHanded_RunState(Animator anim) : base(anim)
    {

    }


    public override void Enter()
    {
        base.Enter();
        //Debug.Log("Enter TwoHanded_RunState");
        anim.StopPlayback();
        anim.CrossFade(animBase.TwoHanded_Run, 0.1f);
    }

    public override void Exit()
    {
        base.Exit();
        //Debug.Log("Exit TwoHanded_RunState");
        anim.StopPlayback();
    }

    public override void Update()
    {
        base.Update();

  

    }
}
