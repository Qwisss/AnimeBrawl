using System;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Player _player;
    [SerializeField] protected PlayerLocomotion _playerLocomotion;

    [Header("Animations")]
    private StateMachine _stateMachine;
    protected RunState _runState;

    protected HashAnimationNames _animBase = new HashAnimationNames();

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        _stateMachine = new StateMachine();
        _stateMachine.Initialize(new IdleState(_player.animator));


        _playerLocomotion.OnIdleEvent += HandleIdleStart;
        _playerLocomotion.OnMoveEvent += HandleRunStart;
        _playerLocomotion.OnAttackEvent += HandleHightKickStart;
        _playerLocomotion.OnFightIdleEvent += HandleFightIdleStart;

    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    #region IdleState
    private void HandleIdleStart()
    {
        if (!IsIdleState())
        {
            _stateMachine.ChangeState(new IdleState(_player.animator));
        }
    }

    private bool IsIdleState()
    {
        return _stateMachine.CurrentState.GetType() == typeof(IdleState);
    }

    #endregion

    #region RunState
    private void HandleRunStart()
    {
        if (!IsRunningState())
        {
            _stateMachine.ChangeState(new RunState(_player.animator));
        }
    }

    private bool IsRunningState()
    {
        return _stateMachine.CurrentState.GetType() == typeof(RunState);
    }
    #endregion

    #region HightKickState

    private void HandleHightKickStart()
    {
        if (!IsHightKickState())
        {
            _stateMachine.ChangeState(new HightKickState(_player.animator));
        }
    }

    private bool IsHightKickState()
    {
        return _stateMachine.CurrentState.GetType() == typeof(HightKickState);
    }

    #endregion

    #region FightIdleState
    private void HandleFightIdleStart()
    {
        if (!IsFightIdleState())
        {
            _stateMachine.ChangeState(new FightIdleState(_player.animator));
        }
    }

    private bool IsFightIdleState()
    {
        return _stateMachine.CurrentState.GetType() == typeof(FightIdleState);
    }

    #endregion
}
