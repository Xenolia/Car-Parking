using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<PrometeoCarController>() != null)
        {
            CheckPointPassed(); 
        }
    }

    void CheckPointPassed()
    {
        GetComponentInParent<Level>().CheckPointPassed(gameObject);
    }
}
