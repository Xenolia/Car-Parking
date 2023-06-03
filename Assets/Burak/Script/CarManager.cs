using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarManager : MonoBehaviour
{
    [SerializeField] GameObject[] Cars;

    public void ActivateCar(int index)
    {
        Cars[index].SetActive(true);
    }
}
