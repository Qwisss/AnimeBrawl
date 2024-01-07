using System;
using UnityEngine;

public class CharacterAnimationController : AnimationControllerBase
{
    [Header("Components")]
    [SerializeField] protected CharacterMovement _characterMovement;
    [SerializeField] protected AttackHandler _attackHandler;
    [SerializeField] protected Character _character;
    public Animator Animator;

    [Header("Animations")]
    private StateMachine _stateMachine;


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

        _attackHandler.OnAttackEvent += HandleAttackStart;

        _character.OnDeathEvent += HandleDeathStart;
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

        if (!IsAttackState() || !Animator.IsInTransition(0))
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
