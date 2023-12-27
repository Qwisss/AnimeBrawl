using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] protected CharacterMovement _characterMovement;
    public Animator Animator;

    [Header("Animations")]
    private StateMachine _stateMachine;
    //protected RunState _runState;

    protected HashAnimationNames _animBase = new HashAnimationNames();

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(new TwoHanded_IdleState(Animator));


        _characterMovement.OnIdleEvent += HandleIdleStart;
        _characterMovement.OnMoveEvent += HandleRunStart;
        _characterMovement.OnAttackEvent += HandleAttackStart;
       // _characterMovement.OnFightIdleEvent += HandleDeathStart;
    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    #region TwoHanded

    #region IdleState
    private void HandleIdleStart()
    {
        if (!IsIdleState())
        {
            _stateMachine.ChangeState(new TwoHanded_IdleState(Animator));
        }
    }

    private bool IsIdleState()
    {
        return _stateMachine.CurrentState.GetType() == typeof(TwoHanded_IdleState);
    }

    #endregion

    #region RunState
    private void HandleRunStart()
    {
        if (!IsRunState())
        {
            _stateMachine.ChangeState(new TwoHanded_RunState(Animator));
        }
    }

    private bool IsRunState()
    {
        return _stateMachine.CurrentState.GetType() == typeof(TwoHanded_RunState);
    }
    #endregion

    #region AttackState

    private void HandleAttackStart()
    {
        if (!IsAttackState())
        {
            _stateMachine.ChangeState(new TwoHanded_AttackState(Animator));
        }
    }

    private bool IsAttackState()
    {
        return _stateMachine.CurrentState.GetType() == typeof(TwoHanded_AttackState);
    }

    #endregion

    #region DeathkState

    private void HandleDeathStart()
    {
        if (!IsDeathState())
        {
            _stateMachine.ChangeState(new TwoHanded_DeathState(Animator));
        }
    }

    private bool IsDeathState()
    {
        return _stateMachine.CurrentState.GetType() == typeof(TwoHanded_DeathState);
    }

    #endregion

#endregion
}
