using UnityEngine;

public class InteractionController
{
    private static InteractionController instance;

    public static InteractionController Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new InteractionController();
            }

            return instance;
        }
    }

    public void ProcessInteraction(UnitModel model, Collider2D contact)
    {
        if (contact.gameObject.TryGetComponent<ProjectileView>(out ProjectileView projectileView) == true)
        {
            if (projectileView.Projectile is Bullet bullet)
            {
                model.InvokeAttacked(bullet);
                bullet.IsDead = true;
                return;
            }

            if (projectileView.Projectile is PowerUp powerUp)
            {
                PowerUpModifier.Instance.ApplyPowerUpToModel(model, powerUp);
            }
        }

        var view = contact.gameObject.GetComponentInParent<UnitView>();

        if (view != null)
        {
            // UnitHealthApplicator.ApplyHealthDelta(10);
            model.ApplyDamage(10);
        }
    }
}
