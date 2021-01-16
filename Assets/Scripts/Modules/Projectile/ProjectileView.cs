using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class ProjectileView : MonoBehaviour
{
    private Projectile _projectile;
    private Collider2D _collider;
    private SpriteRenderer _spriteRenderer;
    private Animator _animator;

    public Projectile Projectile => _projectile;

    public void Start()
    {
        _collider = gameObject.GetComponent<Collider2D>();
    }

    public void Initialize(Projectile projectile)
    {
        _projectile = projectile;
        _spriteRenderer = GetComponent<SpriteRenderer>();

        if (projectile is Bullet)
        {
            _animator = GetComponent<Animator>();
            _animator.SetBool("PlayerProjectile", true);
        }
        else if (projectile is PowerUp powerUp)
        {
            _animator = GetComponent<Animator>();
            _animator.enabled = false;
            _spriteRenderer.sprite = Resources.Load<Sprite>("Icons/PowerUps/" + powerUp.Type);
        }
    }

    public void DestroyObject()
    {
        Destroy(gameObject);
    }

    private void Update()
    {
        if (_projectile.IsDead && _collider.enabled)
        {
            // TODO: spawn explosion object
            DestroyObject();
        }

        transform.position = _projectile.Position;
    }

    public void SetPlayerBulletFlyAnimation()
    {
        _animator.SetBool("PlayerProjectile", false);
        _animator.SetBool("PlayerBulletFlyAnimation", true);
    }
}
