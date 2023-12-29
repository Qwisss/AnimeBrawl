using System;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public enum Statistic
{
    Life, 
    Damage,
    Armor,
    AttackSpeed
}

[Serializable]
public class StatsValue
{
    public Statistic StatisticType;
    public bool IsfloatType;

    public int Integer_value;

    public float Float_value;

    public StatsValue(Statistic statisticType, int value = 0)
    {
        StatisticType = statisticType;
        Integer_value = value;
        IsfloatType = false;
    }

    public StatsValue(Statistic statisticType, float float_value = 0f)
    {
        StatisticType = statisticType;
        Float_value = float_value;
        IsfloatType = true;
    }
}

[Serializable]
public class StatsGroup
{
    public List<StatsValue> Stats;
    
    public StatsGroup()
    {
        Stats = new List<StatsValue>();
    }

    public void Init()
    {
        Stats.Add(new StatsValue(Statistic.Life, 100));
        Stats.Add(new StatsValue(Statistic.Damage, 8));
        Stats.Add(new StatsValue(Statistic.Armor, 3));
        Stats.Add(new StatsValue(Statistic.AttackSpeed, 1f));
    }

    public StatsValue Get(Statistic statisticToGet)
    {
        return Stats[(int)statisticToGet];
    }
}

public enum Attribute
{
    Strength,
    Dexterity,
    Intelligence
}

[Serializable]
public class AttributeValue
{
    public Attribute AttributeType;
    public int Value;

    public AttributeValue(Attribute attributeType, int value = 0)
    {
        AttributeType = attributeType;
        Value = value;
    }
}

[Serializable]
public class AttributeGroup
{
    public List<AttributeValue> AttributeValues;

    public AttributeGroup()
    {
        AttributeValues = new List<AttributeValue>();
    }

    public void Init()
    {
        AttributeValues.Add(new AttributeValue(Attribute.Strength));
        AttributeValues.Add(new AttributeValue(Attribute.Dexterity));
        AttributeValues.Add(new AttributeValue(Attribute.Intelligence));
    }
}

[Serializable]
public class ValuePool
{
    public StatsValue MaxValue;
    public int CurrentValue;

    public ValuePool(StatsValue maxValue)
    {
        MaxValue = maxValue;
        CurrentValue = maxValue.Integer_value;
    }
}

public class Character : MonoBehaviour, IDamageable
{
    [SerializeField] private AttributeGroup _attrinutes;
    [SerializeField] private StatsGroup _stats;
    public ValuePool _lifepool;

    public int Health { get; set; }

    public void TakeDamage(int damage)
    {
        damage = ApplyDefence(damage);
        if (damage > 0)
        {
            _lifepool.CurrentValue -= damage;
            if (_lifepool.CurrentValue <= 0)
            {
                Die();
            }
        }
    }

    private int ApplyDefence(int damage)
    {
        damage -= _stats.Get(Statistic.Armor).Integer_value;

        if (damage <= 0)
        {
            damage = 1;
        }

        return damage;

    }

    public void Die() 
    {
        gameObject.SetActive(false);

    }

    private void Start()
    {
        _attrinutes = new AttributeGroup();
        _attrinutes.Init();

        _stats = new StatsGroup();
        _stats.Init();

        _lifepool = new ValuePool(_stats.Get(Statistic.Life));
    }

    public StatsValue TakeStats(Statistic statisticToGet)
    {
        return _stats.Get(statisticToGet);
    }

    public Transform GetTransform()
    {
        throw new NotImplementedException();
    }
}
