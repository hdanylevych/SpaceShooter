using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner
{
    private static UnitSpawner instance;

    private const string UnitViewGameObjectPath = "View/UnitView";
    private const string UnitConfigurationObjectPath = "Configurations/Units/UnitDatabase";
    private const string UnitsAnimationReferencesPath = "Configurations/UnitsAnimationReferences/UnitsAnimationReferences";

    private GameObject _unitViewPrefab;
    private GameObject _playersViewParent = new GameObject("Player's View");
    private GameObject _enemyViewParent = new GameObject("Enemy's View");
    
    private UnitsAnimationReferences _unitsAnimationReferences;
    private UnitDatabase _unitDatabase;

    public static UnitSpawner Instance
    {
        get
        {
            if (instance == null)
                instance = new UnitSpawner();

            return instance;
        }
    }

    private UnitSpawner()
    {
        _unitViewPrefab = Resources.Load<GameObject>(UnitViewGameObjectPath);

        _unitsAnimationReferences = Resources.Load<UnitsAnimationReferences>(UnitsAnimationReferencesPath);

        _unitDatabase = Resources.Load<UnitDatabase>(UnitConfigurationObjectPath);
    }

    public List<UnitModel> CreateArmy(int armySize, bool isPlayer)
    {
        var army = new List<UnitModel>(armySize);

        if (isPlayer == false)
        {
            CreateEnemyArmy(armySize, army);
        }
        else
        {
            CreatePlayerArmy(armySize, army);
        }

        return army;
    }

    private void CreatePlayerArmy(int armySize, List<UnitModel> army)
    {
        // PlayerView init
        var playerViewInstance = GameObject.Instantiate(_unitViewPrefab);
        var playerView = playerViewInstance.GetComponent<UnitView>();

        var model = new UnitModel(_unitDatabase.UnitConfigurations[0]);

        foreach (var animationReference in _unitsAnimationReferences.animationReferences)
        {
            if (animationReference.SkinId == model.SkinId)
            {
                var animationInstantiate = GameObject.Instantiate(animationReference.Animation, playerViewInstance.transform);
                break;
            }
        }

        playerView.Initialize(model);
        army.Add(model);
        playerViewInstance.transform.parent = _playersViewParent.transform;
    }

    private void CreateEnemyArmy(int armySize, List<UnitModel> army)
    {
        for (int i = 0; i < armySize; i++)
        {
            var model = new UnitModel(_unitDatabase.UnitConfigurations[1]);
            var enemyViewGameObject = GameObject.Instantiate(_unitViewPrefab); // EnemyUnitPool.GetEnemy()
            
            model.Position.y = Random.Range(-5, 5);
            model.Position.x = Random.Range(10, 12);

            enemyViewGameObject.transform.parent = _enemyViewParent.transform;
            enemyViewGameObject.GetComponent<UnitView>().Initialize(model);
            
            foreach (var animationReference in _unitsAnimationReferences.animationReferences)
            {
                if (animationReference.SkinId == model.SkinId)
                {
                    var animationInstantiate = GameObject.Instantiate(animationReference.Animation, enemyViewGameObject.transform);
                    break;
                }
            }

            army.Add(model);
        }
    }
}
 