using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] GameObject checkPoint;

    public void CheckPointPassed(GameObject lastCheckPoint)
    {
        checkPoint = lastCheckPoint;
    }

    public GameObject LastCheckPoint()
    {
        return checkPoint;
    }
}
