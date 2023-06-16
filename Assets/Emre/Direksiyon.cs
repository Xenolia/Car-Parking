using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UIElements.Experimental;

public class Direksiyon : MonoBehaviour
{

    public float wheelSpeed;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.DOLocalRotate(new Vector3(transform.rotation.x, -89, transform.rotation.z), wheelSpeed);

        }
        else if (Input.GetKeyUp(KeyCode.A))
        {
            transform.DOLocalRotate(new Vector3(transform.rotation.x, 0, transform.rotation.z), wheelSpeed);
        }


        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.DOLocalRotate(new Vector3(transform.rotation.x, 89, transform.rotation.z), wheelSpeed);

        }
        else if (Input.GetKeyUp(KeyCode.D))
        {
            transform.DOLocalRotate(new Vector3(transform.rotation.x, 0, transform.rotation.z), wheelSpeed);
        }

    }

}
