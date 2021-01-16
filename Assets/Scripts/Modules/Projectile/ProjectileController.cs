using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController
{
    private const string PowerUpViewPath = "Projectiles/ProjectileView";

    private static ProjectileController _instance;

    private List<Projectile> _projectiles;
    private GameObject _powerUpViewPrefab;
    private float _timer;

    public static ProjectileController Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ProjectileController();

            return _instance;
        }
    }

    public IReadOnlyList<Projectile> Projectiles => _projectiles;

    public ProjectileController()
    {
        _projectiles = new List<Projectile>(20);

        _powerUpViewPrefab = Resources.Load<GameObject>(PowerUpViewPath);
    }

    public void Update()
    {
        if (this._timer > 2f)
        {
            var powerUpObject = GameObject.Instantiate(_powerUpViewPrefab);

            powerUpObject.SetActive(true);
            var position = new Vector3(11, 0, 0) + Vector3.left;

            var powerUpView = powerUpObject.GetComponent<ProjectileView>();
            var powerUp = new PowerUp(position, PowerUpType.Heal, 15, Vector3.left, 5);
            powerUpView.Initialize(powerUp);
            ProjectileController.Instance.AddProjectile(powerUp);

            this._timer = 0f;
        }

        foreach (var projectile in _projectiles)
        {
            projectile.Update();
        }

        this._timer += Time.deltaTime;
    }

    public void AddProjectile(Projectile projectile)
    {
        if (this._projectiles.Contains(projectile) == false)
        {
            _projectiles.Add(projectile);
        }
    }

    public void RemoveProjectile(Projectile projectile)
    {
        if (_projectiles.Contains(projectile) == true)
        {
            _projectiles.Remove(projectile);
        }
    }
}
