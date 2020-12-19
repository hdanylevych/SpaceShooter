using UnityEngine;
using System;

[Serializable]
public struct UnitConfiguration
{
    public int Id;
    public int SkinId;
    public string Name;
    public int Hp;
    public int Shield;
    public int MovementSpeed;
    public long AttackDamage;
    public float AttackSpeed;
}
