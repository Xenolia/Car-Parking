using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class SteeringWheel : MonoBehaviour
{
    [SerializeField] float clampDelta=200f;
    [SerializeField] float rotationSpeed = 600f;
    [SerializeField] float deltaChange;
 
    private void Update()
    {
        var horizontalInput = Input.GetAxisRaw("Horizontal")*rotationSpeed*Time.deltaTime;
        deltaChange += horizontalInput;
        deltaChange = Mathf.Clamp(deltaChange, -clampDelta, clampDelta);

        if(Mathf.Approximately(horizontalInput,0f)&& !Mathf.Approximately(deltaChange, 0f)){
             var sign = Mathf.Sign(deltaChange) * -1f;
            deltaChange += sign * rotationSpeed * Time.deltaTime;
             
            transform.Rotate(Vector3.up * sign*rotationSpeed*Time.deltaTime, Space.Self);
            return;
        }

        if (Mathf.Approximately(deltaChange, clampDelta) || Mathf.Approximately(deltaChange, -clampDelta))
            return;

        transform.Rotate(Vector3.up*horizontalInput,Space.Self);
    }
}
