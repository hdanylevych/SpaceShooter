using UnityEngine;

[CreateAssetMenu(fileName = "New UnitConfiguration", menuName = "Scriptable Data/UnitConfig")]
public class UnitConfiguration : ScriptableObject
{
    public int Id;
    public int SkinId;
    public string Name;

    public int Hp;
    public int MovementSpeed;
    public long AttackDamage;
    public float AttackSpeed;

    public Sprite Skin;
}
