using UnityEngine;

public class Skill : ScriptableObject
{
    public string skillName;
}

[System.Serializable]
[CreateAssetMenu(fileName = "New Upgrade Skill", menuName = "Create Skill/Upgrade Skill")]
public class Upgrade : Skill
{
    public PlayerStatType StatType;
    public float UpgradeValue;
}

[System.Serializable]
[CreateAssetMenu(fileName = "New Upgrade Skill", menuName = "Create Skill/Weapon Skill")]
public class Weapon : Skill
{
    public GameObject weaponPrefab;
    public float weaponAttackCooldown;

}