using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController
{
    private List<UnitModel> _army;
    private IMovementController _movementController;
    private GameControls _playerControls;

    public UnitController(IMovementController movementController, List<UnitModel> army)
    {
        _army = army;
        _movementController = movementController;

        _playerControls = new GameControls();
        _playerControls.Enable();
    }

    public void UpdateMethod()
    {
        foreach (var unitModel in _army)
        {
            _movementController.Update(unitModel);
            UpdateAttack(unitModel);
        }

        CheckModelOnBecameInvisable();

        if (_army.Count == 0)
            _army = UnitSpawner.Instance.CreateArmy(30, false);
    }

    private void UpdateAttack(UnitModel model)
    {
        if (_playerControls.PlayerShip.Fire.ReadValue<float>() > 0f)
        {
            var projectilePrefab = Resources.Load<GameObject>("Projectiles/Projectile");
            var projectileObject = GameObject.Instantiate(projectilePrefab);

            projectileObject.transform.position = model.Position;
            projectileObject.GetComponent<Projectile>().StartMoving();
        }
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
