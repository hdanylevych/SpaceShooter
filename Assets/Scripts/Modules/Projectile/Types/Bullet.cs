using UnityEngine;

public class Bullet : Projectile, IAttacker
{
    private long _damage;
    public long Damage => _damage;

    public Bullet(Vector3 position, Vector3 direction, float speed, long attackDamage)
    {
        _position = position;
        _direction = direction;
        _speed = speed;
        _damage = attackDamage;
    }
}
