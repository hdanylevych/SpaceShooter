using System;
using UnityEngine;

public class UnitModel
{
    private long _health;
    private UnitConfiguration _configuration;

    public Vector3 Position = new Vector3(-3, 0, 0);

    public long Health
    {
        get => _health;

        private set
        {
            _health = value;
        }
    }

    public int MaxHealth => _configuration.Hp;
    public bool IsDead => Health <= 0;
    public long AttackDamage => _configuration.AttackDamage;
    public float AttackSpeed => _configuration.AttackSpeed;
    public int SkinId => _configuration.SkinId;
    public int MovementSpeed => 3;

    public event Action<UnitModel, IAttacker> Attacked;
    public event Action<UnitModel> OnDeath;

    public UnitModel(UnitConfiguration config)
    {
        _configuration = config;
        Health = config.Hp;
    }

    public void ApplyDamage(long damage)
    {
        Health -= damage;

        if (IsDead)
        {
            OnDeath?.Invoke(this);
        }
    }

    public void DeleteModel()
    {
        OnDeath?.Invoke(this);
    }


    public void InvokeAttacked(IAttacker attacker)
    {
        Attacked?.Invoke(this, attacker);
    }
}
