using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    Vector3 startPos;
    Quaternion startRot;
    GameController gameController;
    private void Awake()
    {
        startPos = transform.position;
        startRot = transform.rotation;
        gameController = GetComponentInParent<GameController>();
    }
    private void OnEnable()
    {
        gameController.OnRevive += Revive;
    }
    private void OnDisable()
    {
        gameController.OnRevive -= Revive;
 
    }
    void Revive()
    {
        if(GetComponent<Rigidbody>()!=null)
        GetComponent<Rigidbody>().velocity = Vector3.zero;

        transform.SetPositionAndRotation(startPos,startRot);
     }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponent<PrometeoCarController>()!=null)
        {
            FindObjectOfType<GameController>().LevelLose();
        }
        if (collision.gameObject.GetComponentInParent<PrometeoCarController>() != null)
        {
            FindObjectOfType<GameController>().LevelLose();
        }
    } 
}
