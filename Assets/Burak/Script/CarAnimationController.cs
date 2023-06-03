using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class CarAnimationController : MonoBehaviour
{
   [SerializeField] DOTweenAnimation placementAnim;
    private void OnEnable()
    {
        placementAnim.DORestart();
    }
}
