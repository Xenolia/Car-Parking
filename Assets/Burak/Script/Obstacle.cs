using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    Vector3 startPos;
    Quaternion startRot;
    GameController gameController;
    bool godmode;
    private void Awake()
    {
        godmode = false;
        startPos = transform.position;
        startRot = transform.rotation;
        gameController = FindObjectOfType<GameController>();
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

        if (godmode)
            return;

        if(collision.gameObject.GetComponent<PrometeoCarController>()!=null)
        {
            FindObjectOfType<GameController>().LevelLose();
        }
        if (collision.gameObject.GetComponentInParent<PrometeoCarController>() != null)
        {
            FindObjectOfType<GameController>().LevelLose();
        }
        if (collision.gameObject.GetComponent<WheelCollider>() != null)
        {
            FindObjectOfType<GameController>().LevelLose();
        }
    } 
}
