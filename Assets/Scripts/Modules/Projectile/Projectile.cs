using UnityEngine;

public class Projectile
{
    protected float _speed;
    protected Vector3 _direction;
    protected Vector3 _position;

    public bool IsDead { get; set; }
    public Vector3 Position => _position;

    public virtual void Update()
    {
        if (IsDead == true)
            return;

        if (_position.x > 12 || _position.x < -12)
        {
            IsDead = true;
        }
        
        _position += _direction * (_speed * Time.deltaTime);
    }
}