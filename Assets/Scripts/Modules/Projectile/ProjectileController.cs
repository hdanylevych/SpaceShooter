using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController
{
    private static ProjectileController _instance;

    private List<Projectile> _projectiles;

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
    }

    public void Update()
    {
        foreach (var projectile in _projectiles)
        {
            projectile.Update();
        }
    }

    public void AddProjectile(Projectile projectile)
    {
        if (this._projectiles.Contains(projectile) == false)
        {
            _projectiles.Add(projectile);
        }
    }

    private void RemoveProjectile(Projectile projectile)
    {
        if (this._projectiles.Contains(projectile) == true)
        {
            _projectiles.Remove(projectile);
        }
    }
}
