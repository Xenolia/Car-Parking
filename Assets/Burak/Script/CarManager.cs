using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] GameObject[] Cars;
    [SerializeField] GameObject CurrentCar;
    [SerializeField] GameObject rain;
    private void Start()
    {
        if (Random.value < 0.2f)
        {
            SetRain();
        }
    }
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
    }
    public void ChangeCamera()
    {
        CurrentCar.GetComponent<CameraSwitch>().ChangeCam();
    }
}
