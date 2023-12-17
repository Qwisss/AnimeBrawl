using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ScriptableObject that holds the BASE STATS for an player. These can then be modified at object creation time to buff up players
/// and to reset their stats if they died or were modified at runtime.
/// </summary>

[CreateAssetMenu(fileName = "Player Configuration", menuName = "ScriptableObject/Player Configuration")]
public class PlayerScriptableObject : ScriptableObject
{

}
