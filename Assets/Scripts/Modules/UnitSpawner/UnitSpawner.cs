using System.Collections.Generic;
using UnityEngine;

public class UnitSpawner
{
    private static UnitSpawner instance;

    private const string EnemyViewGameObjectPath = "View/EnemyView";
    private const string EnemyConfigurationObjectPath = "Configurations/Enemies/";
    private const string PlayerViewGameObjectPath = "View/PlayerView";
    private const string PlayerConfigurationObjectPath = "Configurations/Player/";

    private GameObject _enemyViewPrefab;
    private GameObject _playerViewPrefab;
    
    private GameObject _playersViewParent = new GameObject("Player's View");
    private GameObject _enemysViewParent = new GameObject("Enemy's View");
    
    private UnitConfiguration _defaultEnemyConfiguration;
    private UnitConfiguration _defaultPlayerConfiguration;

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
        _playerViewPrefab = Resources.Load<GameObject>(PlayerViewGameObjectPath);
        _enemyViewPrefab = Resources.Load<GameObject>(EnemyViewGameObjectPath);

        _defaultEnemyConfiguration = Resources.Load<UnitConfiguration>(EnemyConfigurationObjectPath + "Default");
        _defaultPlayerConfiguration = Resources.Load<UnitConfiguration>(PlayerConfigurationObjectPath + "Base");
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
        var playerViewInstance = GameObject.Instantiate(_playerViewPrefab);
        var playerView = playerViewInstance.GetComponent<UnitView>();

        var unitModel = new UnitModel(_defaultPlayerConfiguration);
        playerView.Initialize(unitModel);

        army.Add(unitModel);
        playerViewInstance.transform.parent = _playersViewParent.transform;
    }

    private void CreateEnemyArmy(int armySize, List<UnitModel> army)
    {
        for (int i = 0; i < armySize; i++)
        {
            var model = new UnitModel(_defaultEnemyConfiguration);
            var enemyViewGameObject = GameObject.Instantiate(_enemyViewPrefab); // EnemyUnitPool.GetEnemy()
            
            model.Position.y = Random.Range(-5, 5);
            model.Position.x = Random.Range(10, 12);

            enemyViewGameObject.transform.parent = _enemysViewParent.transform;
            enemyViewGameObject.GetComponent<UnitView>().Initialize(model);
            
            army.Add(model);
        }
    }
}
 