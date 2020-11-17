using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageApplicationController
{
    void ApplyDamage(UnitModel target, IAttacker attacker);
}
