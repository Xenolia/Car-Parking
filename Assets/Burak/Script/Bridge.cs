using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class Bridge : MonoBehaviour
{
    [SerializeField] float duration =3f;
    [SerializeField] Vector3 targetRotation= new Vector3();
    
   public void Rotate()
    {
        transform.DOLocalRotate(targetRotation, duration);
    }
}
