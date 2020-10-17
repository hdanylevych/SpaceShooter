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
        var value = _controls.PlayerShip.Up.ReadValue<float>();
        model.Position.y += value * Time.deltaTime;
        
        value = _controls.PlayerShip.Down.ReadValue<float>();
        model.Position.y -= value * Time.deltaTime;
    }

    ~PlayerMovementController()
    {
    }
}
