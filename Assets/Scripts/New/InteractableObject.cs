using UnityEngine;

public class InteractableObject : MonoBehaviour, IInteractable
{

    [SerializeField] private string _info;
    public string ObjectName;


    private void Awake()
    {
        ObjectName = transform.name;
    }

    public void Interact()
    {
        Debug.Log(_info);
    }

    public Transform GetTransform()
    {
       return transform;
    }
}
