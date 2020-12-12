using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileView : MonoBehaviour
{
    private Projectile _projectile;
    private Collider2D _collider;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;

    public Projectile Projectile => this._projectile;

    public void Start()
    {
        _collider = gameObject.GetComponent<Collider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void Initialize(Projectile projectile)
    {
        _projectile = projectile;

        _animator = GetComponent<Animator>();
        _animator.SetBool("PlayerProjectile", true);
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (_projectile.IsDead && this._collider.enabled)
        {
            // TODO: spawn explosion object
            DestroyObject();
        }

        transform.position = _projectile.Position;
    }

    public void SetPlayerBulletFlyAnimation()
    {
        _animator.SetBool("PlayerProjectile", false);
        this._animator.SetBool("PlayerBulletFlyAnimation", true);
    }
}
