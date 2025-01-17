 using UnityEngine; 
using UnityEditor;
using DG.Tweening;
using UnityEngine.Rendering;
public class PassengerController : MonoBehaviour
{
    [SerializeField] Animator[] controllers;
    [SerializeField] Transform targetTransform;
    [SerializeField] float duration=2.5f;

    public void Init(Animator[] animators)
    {
        controllers = animators;
        Invoke("Move", 2f);
    }

      void Move()
    {
        foreach (var item in controllers)
        {
            item.SetBool("Walk", true);
            Debug.Log(item.speed);
            item.speed = Random.Range(05f, 1f);
            MovePassengers(item);
        }

        Invoke("ActivateCarMovement",duration+1);
 
     }
    void ActivateCarMovement()
    {
        CarManager manager;
        manager=FindFirstObjectByType<CarManager>();
        manager.ActivateMove();
    }
    void MovePassengers(Animator asd)
    {
         
            asd.transform.DOMove(targetTransform.position,duration+Random.Range(0,1f));
        asd.gameObject.transform.LookAt(targetTransform.position);
         
    }

}
