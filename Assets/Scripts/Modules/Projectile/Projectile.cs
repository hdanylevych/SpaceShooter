using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile
{
    private float _speed;
    private Vector3 _direction;
    private Vector3 _position;

    public Vector3 Position => _position;

    public void Initialize(Vector3 direction, Vector3 position, float speed)
    {
        _direction = direction;
        _speed = speed;
        _position = position;
    }

    public virtual void Update()
    {
        _position += _direction * (_speed * Time.deltaTime);
    }
}
