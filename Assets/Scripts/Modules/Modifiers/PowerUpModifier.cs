using UnityEngine;

public class PowerUpModifier
{
    private static PowerUpModifier instance;

    public static PowerUpModifier Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new PowerUpModifier();
            }

            return instance;
        }
    }

    public void ApplyPowerUpToModel(UnitModel model, PowerUp powerUp)
    {
        switch (powerUp.Type)
        {
            case PowerUpType.None:
                Debug.Log($"PowerUpModifier: got powerUp with type {powerUp.Type}.");
                break;
            case PowerUpType.Heal:
                // model.ApplyHealthDelta(powerUp.Value);
                break;
            case PowerUpType.Shields:
                // model.ApplyShieldsDelta(powerUp.Value)
                break;
            default:
                Debug.Log($"PowerUpModifier: cannot apply powerUp with type {powerUp.Type}.");
                break;
        }
    }
}
