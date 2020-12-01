using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingController : IShootingController
{
    private GameControls _playerControls;
    private Vector3 _bulletSpawnPosition;

    public PlayerShootingController()
    {
        _playerControls = new GameControls();
        _playerControls.Enable();
    }

    public void Update(UnitModel model)
    {
        _bulletSpawnPosition = model.Position;
        
        if (_playerControls.PlayerShip.Fire.ReadValue<float>() != 0f)
        {
            Shoot(model);
        }
    }

    private void Shoot(UnitModel model)
    {
        var projectileObject = ProjectilePool.GetProjectile();

        projectileObject.SetActive(true);
        projectileObject.transform.position = _bulletSpawnPosition + Vector3.right;

        var projectile = projectileObject.GetComponent<Projectile>();
        //projectile.SetNewConfigurations(Vector2.right, 200, model.AttackDamage);
    }
}
