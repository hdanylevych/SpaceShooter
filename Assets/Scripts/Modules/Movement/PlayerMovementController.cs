using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : IMovementController
{
    private GameControls _controls;

    public PlayerMovementController()
    {
        _controls = new GameControls();
        _controls.Enable();
    }

    public void Update(UnitModel model)
    {
        var direction = _controls.PlayerShip.Movement.ReadValue<Vector2>();
        model.Position += (Vector3)direction * model.MovementSpeed * Time.deltaTime;
    }

    ~PlayerMovementController()
    {
    }
}
