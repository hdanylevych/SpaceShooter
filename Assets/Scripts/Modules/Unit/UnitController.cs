using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController
{
    private GameControls _playerControls;
    private List<UnitModel> _army;
    private IMovementController _movementController;
    private IShootingController _shootingController;

    public UnitController(IMovementController movementController, IShootingController shootingController, List<UnitModel> army)
    {
        _army = army;
        _movementController = movementController;
        _shootingController = shootingController;

        _playerControls = new GameControls();
        _playerControls.Enable();
    }

    public void UpdateMethod()
    {
        foreach (var unitModel in _army)
        {
            _movementController.Update(unitModel);
            _shootingController.Update(unitModel);
        }

        CheckModelOnBecameInvisable();

        if (_army.Count == 0)
            _army = UnitSpawner.Instance.CreateArmy(30, false);
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
