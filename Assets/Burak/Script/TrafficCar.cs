using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class TrafficCar : MonoBehaviour
{
    Tween asd;
    public void Move(float temp)
    {
         var targetPos = transform.position.x;

   transform.DOLocalMoveX(targetPos - 50f, temp);
        DestroySelf();
    }
 
    public void MoveAndStop(int x)
    {
        var targetPos = transform.position.x;

        transform.DOLocalMoveX(targetPos - (10f/x), 3);
    }
    public void Crash()
    {
       var player= FindObjectOfType<PrometeoCarController>().gameObject;
       asd= transform.DOMove(player.transform.position, 0.5f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.GetComponentInParent<PrometeoCarController>()!=null)
        {
            FindObjectOfType<GameController>().LevelLose();
            asd.Kill();
        }
    }
    void DestroySelf()
    {
        GameObject garbage = gameObject;
        Destroy(garbage,3.5f);
    }
}
