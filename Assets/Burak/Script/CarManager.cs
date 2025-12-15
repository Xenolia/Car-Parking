using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] GameObject[] Cars;
    [SerializeField] GameObject CurrentCar;
    [SerializeField] GameObject rain;
 
    void SetRain()
    {
        if (CurrentCar != null)
        {
            rain.transform.parent = CurrentCar.transform;
            rain.SetActive(true);
        }
    }
    public void ActivateCar(int index)
    {
        CurrentCar = Cars[index];
        Cars[index].SetActive(true);
        if (Random.Range(0, 100) < 25) // 20% chance
{
    SetRain();
}
    }
    public void ChangeCamera()
    {
        CurrentCar.GetComponent<CameraSwitch>().ChangeCam();
    }
}
