using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] GameObject[] cars;


    [SerializeField] GameObject[] disableButtons;
    private void Awake()
    {
        Debug.Log("do unlock system");

    }
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
    void EnableButtons()
    {
        foreach (var item in disableButtons)
        {
            item.SetActive(true);
        }
    }
    void DisableButtons()
    {
        foreach (var item in disableButtons)
        {
            item.SetActive(false);
        }
    }
}
