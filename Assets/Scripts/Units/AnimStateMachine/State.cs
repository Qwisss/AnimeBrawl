
using UnityEngine;

public abstract class State 
{

    protected HashAnimationNames animBase = new HashAnimationNames();
    protected Animator anim;

    public State(Animator anim)
    {
        this.anim = anim;
    }

    public virtual void Enter()
    {

    }

    public virtual void Exit()
    {

    }

    public virtual void Update()
    {

    }

}
