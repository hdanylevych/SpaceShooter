using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    private const string UpdateGameObjectPath = "Update/UpdateObject";
    private const string CameraGameObjectPath = "Camera/Camera";
    private const string BackgroundGameObjectPath = "Backgrounds/StarsTexture";
    
    private GameObject _playersViewParent;
    // Start is called before the first frame update
    void Awake()
    {
        // Main camera init
        var cameraPrefab = Resources.Load<GameObject>(CameraGameObjectPath);
        var cameraInstance = Instantiate(cameraPrefab);
        
        // Background init
        var backgroundPrefab = Resources.Load<GameObject>(BackgroundGameObjectPath);
        var backgroundInstance = Instantiate(backgroundPrefab);

        // Update loop init
        var updatePrefab = Resources.Load<GameObject>(UpdateGameObjectPath);
        var updateInstance = Instantiate(updatePrefab);
        var updateController = updateInstance.GetComponent<UpdateObject>();

        updateController.Initialize();

        ProjectilePool.Initialize();

        Destroy(gameObject);
    }
}
