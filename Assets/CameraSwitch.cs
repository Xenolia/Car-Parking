using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField] GameObject cam1, cam2, cam3;

    public void ChangeCam()
    {
        Debug.Log("Change Cam");
        if(cam1.activeInHierarchy)
        {
            Debug.Log("Cam1");
            cam1.SetActive(false);
            cam2.SetActive(true);
            return;
        }
        if (cam2.activeSelf)
        {
            Debug.Log("Cam2");

            cam2.SetActive(false);
            cam3.SetActive(true);
            return;

        }
        if (cam3.activeSelf)
        {

            Debug.Log("Cam3");

            cam3.SetActive(false);
            cam1.SetActive(true);
            return;

        }
    }
}
