using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShootingController : IShootingController
{
    private const string BulletViewPath = "Projectiles/ProjectileView";

    private GameObject _bulletViewPrefab;
    private GameControls _playerControls;
    private Vector3 _bulletSpawnPosition;

    public PlayerShootingController()
    {
        _playerControls = new GameControls();
        _playerControls.Enable();
        _bulletViewPrefab = Resources.Load<GameObject>(BulletViewPath);
    }

    public void Update(UnitModel model)
    {
        model.AttackCooldown += Time.deltaTime;
        _bulletSpawnPosition = model.Position;
        
        if (_playerControls.PlayerShip.Fire.ReadValue<float>() != 0f && model.AttackCooldown >= model.AttackSpeed)
        {
            model.AttackCooldown = 0f;
            Shoot(model);
        }
    }

    private void Shoot(UnitModel model)
    {
        var bulletObject = GameObject.Instantiate(_bulletViewPrefab);

        bulletObject.SetActive(true);
        bulletObject.transform.position = _bulletSpawnPosition + Vector3.right;

        var bulletView = bulletObject.GetComponent<ProjectileView>();
        var bullet = new Bullet(bulletObject.transform.position, Vector3.right, 10, model.AttackDamage);
        bulletView.Initialize(bullet);
        ProjectileController.Instance.AddProjectile(bullet);
    }
}
