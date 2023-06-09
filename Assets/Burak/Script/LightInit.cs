using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightInit : MonoBehaviour
{
    bool workOnce = false;
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.GetComponentInParent<PrometeoCarController>()!=null)
        {
            if (workOnce)
                return;

            workOnce = true;
            GetComponentInParent<TrafficController>().Init();
        }
    }
}
