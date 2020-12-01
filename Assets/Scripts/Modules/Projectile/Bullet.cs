using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Projectile, IAttacker
{
    public long Damage => 20;
}
