using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParkingArea : MonoBehaviour
{
    [SerializeField] GameObject changeMaterial1;
    [SerializeField] GameObject changeMaterial2;

    public GameObject ChangeMaterial1()
    {
        return changeMaterial1;
    }

    public GameObject ChangeMaterial2()
    {
        return changeMaterial2;
    }
}
