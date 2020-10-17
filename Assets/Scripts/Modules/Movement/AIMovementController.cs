using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIMovementController : IMovementController
{
    public void Update(UnitModel model)
    {
        model.Position.x -= Time.deltaTime * 5;
    }
}
