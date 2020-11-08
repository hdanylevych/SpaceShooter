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
        _playerControls.PlayerShip.Fire.performed += _ => Shoot();
    }

    public void Update(UnitModel model)
    {
        _bulletSpawnPosition = model.Position;
    }

    private void Shoot()
    {
        var projectileObject = ProjectilePool.GetProjectile();

        projectileObject.SetActive(true);
        projectileObject.GetComponent<Projectile>().StartMoving(Vector2.right, 200);
        projectileObject.transform.position = _bulletSpawnPosition + Vector3.right;
    }
}
