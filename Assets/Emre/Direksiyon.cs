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

    Vector3 StartPos;


    private void Awake()
    {
        StartPos = transform.rotation.eulerAngles;
    }


    private void Update()
    {
        return;
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.DOLocalRotate(new Vector3(transform.rotation.x, -89, transform.rotation.z), wheelSpeed);

        }
        else if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.LeftArrow))
        {
            transform.DOLocalRotate(new Vector3(transform.rotation.x, 0, transform.rotation.z), wheelSpeed);
        }


        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.DOLocalRotate(new Vector3(transform.rotation.x, 89, transform.rotation.z), wheelSpeed);

        }
        else if (Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.DOLocalRotate(new Vector3(transform.rotation.x, 0, transform.rotation.z), wheelSpeed);
        }

    }

}
