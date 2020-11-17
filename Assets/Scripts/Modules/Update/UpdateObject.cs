using System.Collections.Generic;
using UnityEngine;

public class UpdateObject : MonoBehaviour
{
    private UnitController _enemyController;
    private UnitController _playerController;
    private List<UnitModel> _playerArmy;
    private List<UnitModel> _enemyArmy;

    public void Initialize()
    {
        _playerArmy = UnitSpawner.Instance.CreateArmy(1, true);
        _enemyArmy = UnitSpawner.Instance.CreateArmy(13, false);
        
        _playerController = new UnitController(new PlayerMovementController(), new PlayerShootingController(), _playerArmy);
        _enemyController = new UnitController(new AIMovementController(), new AIShootingController(), _enemyArmy);
    }

    void Update()
    {
        _playerController.UpdateMethod();
        _enemyController.UpdateMethod();


    }
}
