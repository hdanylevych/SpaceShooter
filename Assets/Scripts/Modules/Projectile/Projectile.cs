using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Projectile : MonoBehaviour, IAttacker
{
    private long _damage;
    private CircleCollider2D _collider;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private float _impluseForce;

    public long Damage => _damage;

    public void Initialize()
    {
        _collider = GetComponent<CircleCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _impluseForce = 200;
        _direction = Vector2.right;
    }

    public void SetNewConfigurations(Vector2 direction, float impulseForce, long damage)
    {
        _damage = damage;
        _direction = direction;
        _impluseForce = impulseForce;

        _rigidbody2D.AddForce(_direction * _impluseForce, ForceMode2D.Force);
    }

    public void ReturnToThePool()
    {
        ProjectilePool.ReturnProjectile(gameObject);
    }

    public void StopMoving()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }
}
