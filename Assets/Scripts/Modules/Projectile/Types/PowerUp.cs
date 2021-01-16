using UnityEngine;

public class PowerUp : Projectile
{
    public PowerUpType Type { get; private set; }
    public long Value { get; private set; }

    public PowerUp(Vector3 position, PowerUpType type, long value, Vector3 direction, float speed)
    {
        _speed = speed;
        _direction = direction;
        _position = position;

        Type = type;
        Value = value;
    }
}
