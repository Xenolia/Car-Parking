using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Level : MonoBehaviour
{
     GameObject checkPoint;

    public float Timer=300000f;
 
    public void CheckPointPassed(GameObject lastCheckPoint)
    {
        checkPoint = lastCheckPoint;
    }

    public GameObject LastCheckPoint()
    {
        return checkPoint;
    }
}
