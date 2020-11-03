using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : IShootingController
{
    private GameControls _playerControls;

    public PlayerShootingController()
    {
        _playerControls = new GameControls();
        _playerControls.Enable();
    }

    public void Update(UnitModel model)
    {
        if (_playerControls.PlayerShip.Fire.ReadValue<float>() > 0f)
        {
            var projectilePrefab = Resources.Load<GameObject>("Projectiles/Projectile");
            var projectileObject = GameObject.Instantiate(projectilePrefab);

            projectileObject.transform.position = model.Position;
            var projectile = projectileObject.GetComponent<Projectile>();

            projectile.Initialize();
            projectile.StartMoving(Vector2.right, 200);
        }
    }
}
