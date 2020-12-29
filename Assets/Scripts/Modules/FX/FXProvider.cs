using UnityEngine;

public class FXProvider
{
    private const string ExplosionFXPath = "FX/ExplosionFX";

    private static FXProvider instance;

    private GameObject _explosionPrefab;

    public static FXProvider Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new FXProvider();
            }

            return instance;
        }
    }

    private FXProvider()
    {
        _explosionPrefab = Resources.Load<GameObject>(ExplosionFXPath);
    }

    public GameObject GetFXInstance(FXType type)
    {
        if (type == FXType.Explosion)
        {
            return GameObject.Instantiate(_explosionPrefab);
        }

        return null;
    }
}
