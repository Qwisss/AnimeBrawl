using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.XInput;

public class InteractHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textOnScreen;
    [SerializeField] private InputController inputController;
    [SerializeField] private AttackHandler _attackHandler;
    [SerializeField] private UIPoolBar _UIPoolBar;
    [SerializeField] private CharacterMovement _characterMovement;
    [SerializeField] private Inventory _inventory;

    [HideInInspector] public InteractableObject _interactableObject;
    private Character _characterObject;

    [SerializeField] private float _interactRange = 1f;

    public event Action<Vector3> OnTargetEvent;

    private void Awake()
    {
        if (inputController == null)
        {
            inputController = FindObjectOfType<InputController>();
        }
        if (_UIPoolBar == null)
        {
            _UIPoolBar = FindObjectOfType<UIPoolBar>();
        }
        if (_attackHandler == null)
        {
            _attackHandler = GetComponent<AttackHandler>();
        }
        if (_inventory == null)
        {
            _inventory = GetComponent<Inventory>();
        }
    }

    private void Start()
    {
        inputController.OnHitEvent += GetObject;
        inputController.OnLeftClickEvent += IsInteractObject;

        _attackHandler.OnAttackEvent += UpdateHPBar;
    }

    private void GetObject(RaycastHit hit)
    {
        _interactableObject = hit.transform.GetComponent<InteractableObject>(); 
        if (_interactableObject != null)
        {
            textOnScreen.text = _interactableObject.ObjectName;
            _characterObject = _interactableObject.GetComponent<Character>();
        }
        else
        {
            ClearHoveredObject();
        }
        UpdateHPBar();
    }

    private void IsInteractObject()
    {
        if (_characterObject != null)
        {
            _attackHandler.SetTarget(_characterObject);

        }
        else if(_interactableObject != null)
        {
            _attackHandler.SetTarget(null);
            if (GetDistance(_interactableObject) <= _interactRange)
            {
                _interactableObject.Interact(_inventory);
            }
            else
            {
                StartCoroutine(GoToInteract(_interactableObject));
                OnTargetEvent?.Invoke(_interactableObject.transform.position);
            }

        }
        else
        {
            OnTargetEvent?.Invoke(inputController.MouseInputPosition);
        }
    }

    private IEnumerator GoToInteract(InteractableObject interactableObject)
    {
        WaitForSeconds wait = new WaitForSeconds(Time.deltaTime);

        while (GetDistance(interactableObject) > _interactRange)
        {
            yield return wait;
        }
        _characterMovement.StopDestination();
        interactableObject.Interact(_inventory);
        StopCoroutine(GoToInteract(null));
    }


    private float GetDistance(InteractableObject interactableObject)
    {
        float distance = Vector3.Distance(transform.position, interactableObject.transform.position);


        return distance;
    }

    private void UpdateHPBar()
    {
        if(_characterObject != null)
        {
            _UIPoolBar.Show(_characterObject._lifepool);
        }
        else
        {
            _UIPoolBar.Clear();
        }
    }

    private void ClearHoveredObject()
    {
        _characterObject = null;
        _interactableObject = null;
        textOnScreen.text = "";
    }
}
