﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitModel
{
    private UnitConfiguration _configuration;
    
    public Vector3 Position = new Vector3(-3, 0, 0);

    public bool IsDead => _configuration.Hp <= 0;
    public long AttackDamage => _configuration.AttackDamage;
    public float AttackSpeed => _configuration.AttackSpeed;
    public int SkinId => _configuration.SkinId;
    public int MovementSpeed => 3;
    public BoxCollider2D UnitCollider;

    public UnitModel(UnitConfiguration config)
    {
        _configuration = config;
    }

    public void ApplyDamage(int hp)
    {
        _configuration.Hp -= hp;
    }
}
