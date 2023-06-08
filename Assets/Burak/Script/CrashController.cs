using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrashController : MonoBehaviour
{
    bool workOnce = false;
    public void DisableCrash()
    {
        workOnce = true;
    }
    public void EnableCrash()
    {
        workOnce = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<PrometeoCarController>()!=null)
        {
            if (workOnce)
                return;

            workOnce = true;
            GetComponentInParent<TrafficController>().Crash();

        }
    }
}
