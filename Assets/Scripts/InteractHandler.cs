using System;
using TMPro;
using UnityEngine;

public class InteractHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textOnScreen;
    [SerializeField] private InputController inputController;
    [SerializeField] private AttackHandler _attackHandler;
    [SerializeField] private UIPoolBar _UIPoolBar;

    [HideInInspector] public InteractableObject hoveringOverObject;
    private Character _hoveringOverCharacter;

    public event Action<Character> OnTargetEvent; 

    private void Start()
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
        inputController.OnInteractableObjectEvent += IsInteractableObject;
        _attackHandler.OnAttackEvent += UpdateHPBar;
    }

    private void IsInteractableObject(RaycastHit hit)
    {
        IInteractable interactableObject = hit.transform.GetComponent<IInteractable>();
        if (interactableObject != null)
        {
            IsInteractObject(interactableObject);
        }
        else
        {
            IsInteractObject(null);
        }
    }

    private void IsInteractObject(IInteractable interactableObject)
    {
        if (interactableObject != null)
        {
            InteractableObject obj = interactableObject.GetTransform().gameObject.GetComponent<InteractableObject>();
            _hoveringOverCharacter = obj.GetComponent<Character>();
            OnTargetEvent?.Invoke(_hoveringOverCharacter);
            hoveringOverObject = obj;
            textOnScreen.text = hoveringOverObject.ObjectName;
        }
        else
        {
            OnTargetEvent?.Invoke(null);
            _hoveringOverCharacter = null;
            hoveringOverObject = null;
            textOnScreen.text = "";
        }

        UpdateHPBar();
    }

    private void UpdateHPBar()
    {
        if(_hoveringOverCharacter != null)
        {
            _UIPoolBar.Show(_hoveringOverCharacter._lifepool);
        }
        else
        {
            _UIPoolBar.Clear();
        }
    }
}
