using System.Collections;
using System.Collections.Generic;
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

    private InteractionController()
    {
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
        }

        var view = contact.gameObject.GetComponentInParent<UnitView>();

        if (view != null)
        {
            model.ApplyDamage(10);
        }
    }
}
