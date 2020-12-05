using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ProjectilePool
{
    private static GameObject _parentGameObject;
    private static GameObject _projectilePrefab;
    private static List<GameObject> _pool;

    public static bool Initialized { get; private set; } = false;

    public static void Initialize()
    {
        if (Initialized == true)
            return;

        _projectilePrefab = Resources.Load<GameObject>("Projectiles/ProjectileView");
        _parentGameObject = new GameObject("Projectiles");
        
        GameObject.DontDestroyOnLoad(_parentGameObject);
        
        _pool = new List<GameObject>(2);

        for (int i = 0; i < _pool.Capacity; i++)
        {
            _pool.Add(GetNewProjectile());
        }

        Initialized = true;
    }

    public static GameObject GetProjectile()
    {
        if (_pool.Count > 0)
        {
            var projectile = _pool[_pool.Count - 1];

            _pool.RemoveAt(_pool.Count - 1);
            return projectile;
        }

        _pool.Capacity++;
        return GetNewProjectile();
    }

    public static void ReturnProjectile(GameObject projectile)
    {
        projectile.SetActive(false);
        _pool.Add(projectile);
    }

    private static GameObject GetNewProjectile()
    {
        var projectileObject = GameObject.Instantiate(_projectilePrefab, _parentGameObject.transform);

        projectileObject.SetActive(false);

        return projectileObject;
    }
}
