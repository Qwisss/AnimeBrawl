using Unity.VisualScripting;
using UnityEngine;

public class PlayerLocomotion : MonoBehaviour
{

    [SerializeField] private Player _player;
    [SerializeField] private Joystick _joystick;
  
    private void Awake()
    {
        _player = GetComponent<Player>();
    }

    private void Start()
    {
        Iniatialize();
    }

    private void Iniatialize()
    {

        _joystick = _joystick ?? FindObjectOfType<Joystick>();
    }

    public void SetUpColtrollerType(Joystick joystick, bool isPc)
    {
        if(isPc == true)
        {
                   
        }
        else
        {
            _joystick = joystick;
            //_joystick = FindObjectOfType<Joystick>();
        } 
    }

    private void FixedUpdate()
    {
        Vector3 move = new Vector3(_joystick.Horizontal, 0, _joystick.Vertical); 

        _player.characterController.Move(move * Time.fixedDeltaTime * _player.Speed);

        if(move != Vector3.zero)
        {
            Quaternion toRotation = Quaternion.LookRotation(move, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, _player.RotationSpeed * Time.fixedDeltaTime);
        }
    }
}
