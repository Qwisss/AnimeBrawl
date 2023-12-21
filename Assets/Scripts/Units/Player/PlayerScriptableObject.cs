using UnityEngine;

/// <summary>
/// ScriptableObject that holds the BASE STATS for an player. These can then be modified at object creation time to buff up players
/// and to reset their stats if they died or were modified at runtime.
/// </summary>

[CreateAssetMenu(fileName = "Player Configuration", menuName = "ScriptableObject/Player Configuration")]
public class PlayerScriptableObject : ScriptableObject
{
    [Header("Stats")]
    [Header("Healths")]
    public int MaxHealth = 100;
    public int CurrentHealth = 100;

    [Header("Move")]
    public int Speed = 5;
    public int RotationSpeed = 750;

    [Header("Attack")]
    public int AttackDamage = 10;
    public float AttackCooldown = 1.2f;
}
