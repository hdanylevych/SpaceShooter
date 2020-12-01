using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(Collider2D))]
public class ProjectileView : MonoBehaviour
{
    private Projectile _projectile;
    private CircleCollider2D _collider;
    private Rigidbody2D _rigidbody2D;

    public void Start()
    {
        _collider = GetComponent<CircleCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Projectile projectile)
    {
        _projectile = projectile;
    }

    private void Update()
    {
        transform.position = _projectile.Position;
    }

    private void OnBecameInvisible()
    {
        ProjectilePool.ReturnProjectile(gameObject);
    }
}
