using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController
{
    private List<UnitModel> _army;
    private IMovementController _movementController;

    public UnitController(IMovementController movementController, List<UnitModel> army)
    {
        _army = army;
        _movementController = movementController;
    }

    public void UpdateMethod()
    {
        foreach (var unitModel in _army)
        {
            _movementController.Update(unitModel);
        }

        CheckModelOnBecameInvisable();
    }

    private void CheckModelOnBecameInvisable()
    {
        for (int i = _army.Count - 1; i >= 0; i--)
        {
            if (_army[i].Position.x < -10)
            {
                _army[i] = null;
                _army.RemoveAt(i);
            }
        }
    }
}
