using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class AttackHandler : MonoBehaviour
{
    [SerializeField] private Character _character;
    /*[SerializeField] private InteractHandler _interactHandler;*/
    [SerializeField] private InputController _inputController;
    [SerializeField] private CharacterMovement _characterMovement;
    //public event Action OnIdleEvent;

    [SerializeField] private float _attackRange = 3f;
    [SerializeField] private float _defaulTimeToAttack = 3f;
    [SerializeField] private float _attackTimer;
    [SerializeField] private bool _isCooldown = false;

    private Character _target;
    private Character _currentTarget;

    public event Action OnAttackEvent;

    private void Awake()
    {
        if (_inputController == null)
        {
            _inputController = FindObjectOfType<InputController>();
        }
        if (_characterMovement == null)
        {
            _characterMovement = GetComponent<CharacterMovement>();
        }
    }

    private void Start()
    {
        _inputController.OnLeftClickEvent += Attack;
    }

    public void SetTarget(Character target)
    {
        _target = target;
    }

    private void Attack()
    {
        if (_target != null)
        {
            _target = _currentTarget;
            StartCoroutine(UpdateTimer());
        }
        else
        {
            StopCoroutine(UpdateTimer());
        }
    }

    private void ProcessAttack()
    {
        float distance = Vector3.Distance(transform.position, _target.gameObject.transform.position);

        if (distance < _attackRange)
        {
            if (_isCooldown)
            {
                return;
            }

            _attackTimer = GetAttackTimer();

            _characterMovement.StopDestination();
            OnAttackEvent?.Invoke();

            _target.TakeDamage(_character.TakeStats(Statistic.Damage).Integer_value);

            StartCoroutine(UpdateTimerTick());
        }
        else
        {
            _characterMovement.SetDesctination(_target.gameObject.transform.position);
        }
    }

    private void AttackTimerTick()
    {
        if (_attackTimer >= 0f)
        {
            _attackTimer -= Time.deltaTime;
        }
    }


    private IEnumerator UpdateTimer()
    {
        WaitForSeconds wait = new WaitForSeconds(DataConfig.UpdateRate);

        while (true)
        {
            if (_target == null)
            {
                StopCoroutine(UpdateTimer());
            }
            else
            {
                ProcessAttack();
            }

            yield return wait;
        }

    }

    private IEnumerator UpdateTimerTick()
    {
        WaitForSeconds wait = new WaitForSeconds(Time.deltaTime);

        _isCooldown = true;

        while (_attackTimer > 0)
        {
            AttackTimerTick();
            yield return wait;
        }

        _isCooldown = false;

    }

    float GetAttackTimer()
    {
        float attackTimer = _defaulTimeToAttack;

        attackTimer /= _character.TakeStats(Statistic.AttackSpeed).Float_value;

        return attackTimer;
    }





}
