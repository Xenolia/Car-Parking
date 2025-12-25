using UnityEngine;
using UnityEngine.SceneManagement;

using System;

public class ChaseGameController : MonoBehaviour
{
    [SerializeField] ChaseLevelController chaseLevelController;
    CarManager carManager;
    public Action OnGameEnd;

    private void Awake()
    {
        carManager = FindObjectOfType<CarManager>();
        
        // Initialize Level
        if (chaseLevelController != null)
        {
            chaseLevelController.Init();
        }
        else
        {
            Debug.LogError("ChaseLevelController reference is missing in ChaseGameController!");
        }

        // Activate Car
        EnableCar();
    }

    void EnableCar()
    {
        if (carManager != null)
        {
            int carIndex = PlayerPrefs.GetInt("Car", 1);
            carManager.ActivateCar(carIndex);
        }
        else
        {
            Debug.LogError("CarManager not found in the scene!");
        }
    }

#if UNITY_EDITOR
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
#endif
}
