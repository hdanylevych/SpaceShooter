using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitModel
{
    private UnitConfiguration _configuration;
    
    public Vector3 Position = new Vector3(-3, 0, 0);

    public bool IsDead => _configuration.Hp <= 0;
    public long AttackDamage => _configuration.AttackDamage;
    public float AttackSpeed => _configuration.AttackSpeed;
    public Sprite Skin => _configuration.Skin;


    public UnitModel(UnitConfiguration config)
    {
        _configuration = config;
    }

    public void ApplyDamage(int hp)
    {
        _configuration.Hp -= hp;
    }
}
