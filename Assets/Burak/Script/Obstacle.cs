using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    Vector3 startPos;
    GameController gameController;
    private void Awake()
    {
        startPos = transform.position;
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
    void Revive(Vector3 asd)
    {
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        transform.position = startPos;
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
