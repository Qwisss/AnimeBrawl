using System;
using UnityEngine;

public class EnemyAnimationController : AnimationControllerBase
{
    [Header("Components")]
    [SerializeField] private Enemy _enemy;
    [SerializeField] protected EnemyLocomotion _enemyLocomotion;
    public Animator Animator;

    [Header("Animations")]
    private StateMachine _stateMachine;
    //protected RunState _runState;

    protected HashAnimationNames _animBase = new HashAnimationNames();

    public event Action OnDrawArrowBowEndEvent;

    private void Awake()
    {
        _enemy = GetComponent<Enemy>();
    }

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {
        _stateMachine = new StateMachine();
        //_stateMachine.Initialize(new IdleState(Animator));
        // _enemyLocomotion.attackRadius.OnDrawArrowBowEvent += HandleDrawArrowBowStart;


        /*        _enemyLocomotion.OnIdleEvent += HandleIdleStart;
                _enemyLocomotion.OnMoveEvent += HandleRunStart;
                _enemyLocomotion.OnAttackEvent += HandleHightKickStart;
                _enemyLocomotion.OnFightIdleEvent += HandleFightIdleStart;*/



    }

    private void Update()
    {
        _stateMachine.CurrentState.Update();
    }

    /*  #region IdleState
      private void HandleIdleStart()
      {
          if (!IsIdleState())
          {
              _stateMachine.ChangeState(new IdleState(Animator));
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
              _stateMachine.ChangeState(new RunState(Animator));
          }
      }

      private bool IsRunningState()
      {
          return _stateMachine.CurrentState.GetType() == typeof(RunState);
      }
      #endregion

      #region AttackState

      private void HandleHightKickStart()
      {
          if (!IsHightKickState())
          {
              _stateMachine.ChangeState(new HightKickState(Animator));
          }
      }

      private bool IsHightKickState()
      {
          return _stateMachine.CurrentState.GetType() == typeof(HightKickState);
      }

      #endregion 

      #region DeathState
      private void HandleFightIdleStart()
      {
          if (!IsFightIdleState())
          {
              _stateMachine.ChangeState(new FightIdleState(Animator));
          }
      }

      private bool IsFightIdleState()
      {
          return _stateMachine.CurrentState.GetType() == typeof(FightIdleState);
      }

      #endregion*/



}
