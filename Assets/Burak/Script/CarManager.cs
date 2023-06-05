using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] GameObject[] Cars;
    [SerializeField] GameObject CurrentCar;

    public void ActivateCar(int index)
    {
        CurrentCar = Cars[index];
        Cars[index].SetActive(true);
    }
    public void ChangeCamera()
    {
        CurrentCar.GetComponent<CameraSwitch>().ChangeCam();
    }
}
