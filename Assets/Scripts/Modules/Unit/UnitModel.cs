using System;
using UnityEngine;

public class UnitModel
{
    public Vector3 Position = new Vector3(-3, 0, 0);

    private long _health;
    private long _shield;
    private UnitConfiguration _configuration;
    private float _attackCooldown;

    public long Health
    {
        get => _health;

        private set
        {
            _health = value;
        }
    }

    public long Shield
    {
        get => _shield;

        private set
        {
            _shield = value;
        }
    }

    public float AttackCooldown
    {
        get => _attackCooldown;

        set
        {
            _attackCooldown = value;
        }
    }

    public int MaxHealth => _configuration.Hp;
    public int MaxShield => _configuration.Shield;
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
