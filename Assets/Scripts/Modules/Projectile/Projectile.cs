using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(CircleCollider2D))]
public class Projectile : MonoBehaviour
{
    private CircleCollider2D _collider;
    private Rigidbody2D _rigidbody2D;
    private Vector2 _direction;
    private float _impluseForce;

    public void Initialize()
    {
        _collider = GetComponent<CircleCollider2D>();
        _rigidbody2D = GetComponent<Rigidbody2D>();

        _impluseForce = 200;
        _direction = Vector2.right;
    }

    public void StartMoving(Vector2 direction, float impulseForce)
    { 
        _direction = direction;
        _impluseForce = impulseForce;

        _rigidbody2D.AddForce(_direction * _impluseForce, ForceMode2D.Force);
    }

    public void StopMoving()
    {
        _rigidbody2D.velocity = Vector2.zero;
    }
}
