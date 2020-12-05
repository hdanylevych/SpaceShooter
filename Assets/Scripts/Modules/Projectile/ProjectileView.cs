using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileView : MonoBehaviour
{
    private Projectile _projectile;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;

    public Projectile Projectile => this._projectile;

    public void Start()
    {
        _collider = gameObject.GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Projectile projectile)
    {
        _projectile = projectile;
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (_projectile.IsDead)
        {
            DestroyObject();
        }

        transform.position = _projectile.Position;
    }
}
