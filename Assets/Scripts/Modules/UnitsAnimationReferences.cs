using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UnitsAnimationReferences", menuName = "Scriptable Data/UnitsAnimationReferences")]
public class UnitsAnimationReferences : ScriptableObject
{
    public AnimationReference[] animationReferences;
}

[Serializable]
public class AnimationReference
{
    public int SkinId;
    public GameObject Animation;
}
