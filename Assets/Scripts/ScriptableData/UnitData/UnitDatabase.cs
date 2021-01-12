using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New UnitConfiguration", menuName = "Scriptable Data/UnitDatabase")]
public class UnitDatabase : ScriptableObject
{
    public UnitConfiguration[] UnitConfigurations;
}
