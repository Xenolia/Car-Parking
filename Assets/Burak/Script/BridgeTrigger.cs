using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BridgeTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponentInParent<PrometeoCarController>()!=null)
        {
            GetComponentInParent<Bridge>().Rotate();
        }
    }
}
