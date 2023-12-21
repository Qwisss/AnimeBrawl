using System.Collections.Generic;
using UnityEngine;

public enum PlayerStatType
{
    Speed,
    Damage, 
    AttackSpeed,
    AttackCooldown
}

[RequireComponent(typeof(PlayerLocomotion))]
[RequireComponent(typeof(HealthSystemBase))]

public class Player : MonoBehaviour
{
    [Header("Components")]
    public PlayerScriptableObject PlayerScriptableObject;

    public PlayerLocomotion PlayerLocomotion;
    public AnimationController AnimationController;
    public HealthSystemBase HealthSystemBase;

    [Header("Bars")]
    [SerializeField] private ArmorBar _armorBar;
    [SerializeField] private ManaBar _manaBar;

    [Header("Lists")]
    public List<Upgrade> ActiveUpgrades = new List<Upgrade>();
    public List<Weapon> ActiveWeapon = new List<Weapon>();

    private void Awake()
    {
        PlayerLocomotion = GetComponent<PlayerLocomotion>();
        AnimationController = GetComponent<AnimationController>();
        HealthSystemBase = GetComponent<HealthSystemBase>();

        Iniatialize();
    }

    private void Iniatialize()
    {
        PlayerLocomotion.SetupConfiguration(PlayerScriptableObject.Speed, PlayerScriptableObject.RotationSpeed,PlayerScriptableObject.AttackDamage, PlayerScriptableObject.AttackCooldown);
        //AnimationController.SetupConfiguration()
        HealthSystemBase.SetupConfiguration(PlayerScriptableObject.MaxHealth, PlayerScriptableObject.CurrentHealth);
    }
}
