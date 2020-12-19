using System.Collections.Generic;
using UnityEngine;

public class UnitView : MonoBehaviour
{
    private UnitModel _model;
    private Collider2D _collider;
    private List<Collider2D> _contacts;
    
    public UnitModel Model => _model;

    private void Start()
    {
        _collider = gameObject.GetComponentInChildren<Collider2D>();
    }

    public void Initialize(UnitModel unitModel)
    {
        _model = unitModel;
        _contacts = new List<Collider2D>(10);
        _model.OnDeath += OnUnitDeath;
    }

    private void Update()
    {
        transform.position = Model.Position;

        CheckCollisionContacts();
    }

    private void CheckCollisionContacts()
    {
        _collider.OverlapCollider(new ContactFilter2D(), _contacts);

        if (_contacts.Count > 0)
        {
            foreach (var contact in _contacts)
            {
                // TODO: create interaction controller
                if (contact.gameObject.TryGetComponent<ProjectileView>(out ProjectileView projectileView) == true)
                {
                    if (projectileView.Projectile is Bullet bullet)
                    {
                        _model.InvokeAttacked(bullet);
                        bullet.IsDead = true;
                    }
                }

                var view = contact.gameObject.GetComponentInParent<UnitView>();

                if (view != null)
                {
                    Model.ApplyDamage(10);
                }
            }
        }
    }

    private void OnUnitDeath(UnitModel model)
    {
        _model.OnDeath -= OnUnitDeath;
        
        // spawn explosion effect.
        // effect.position = Model.position;
        // effect.SetActive(true);
        // effect.Play();
        
        Destroy(gameObject);
    }
}
