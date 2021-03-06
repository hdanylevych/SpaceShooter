﻿using System.Collections.Generic;

public class UnitController
{
    private List<UnitModel> _army;
    private IMovementController _movementController;
    private IShootingController _shootingController;

    public UnitController(IMovementController movementController, IShootingController shootingController, List<UnitModel> army)
    {
        _army = army;
        _movementController = movementController;
        _shootingController = shootingController;


        SignUpToAttacked(_army);
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
        {
            _army = UnitSpawner.Instance.CreateArmy(10, false);
            SignUpToAttacked(_army);
        }
    }

    private void CheckModelOnBecameInvisable()
    {
        for (int i = _army.Count - 1; i >= 0; i--)
        {
            if (_army[i].Position.x < -10)
            {
                _army[i].Attacked -= OnAttacked;
                _army[i].DeleteModel();
            }
        }
    }

    private void SignUpToAttacked(List<UnitModel> army)
    {
        foreach (var unitModel in army)
        {
            unitModel.Attacked += OnAttacked;
            unitModel.OnDeath += OnModelDeath;
        }
    }

    private void OnAttacked(UnitModel unitModel, IAttacker attacker)
    {
        unitModel.ApplyDamage(attacker.Damage);
    }

    private void OnModelDeath(UnitModel model)
    {
        _army.Remove(model);
    }
} 
