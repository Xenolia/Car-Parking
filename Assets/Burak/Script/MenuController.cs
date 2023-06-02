using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject[] cars;
        public void LoadGame()
    {
        SceneManager.LoadScene(1);
    }

    public void NextCar()
    {

    }
    public void PreviousCar()
    {

    }
     
}
