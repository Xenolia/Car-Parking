using UnityEngine;

public class CameraTutor : MonoBehaviour
{
    bool workOnce=false;
    private void OnTriggerEnter(Collider other)
    {
        if(workOnce)
        {
            return;
        }
        if (other.gameObject.GetComponentInParent<PrometeoCarController>()!=null)
        {
            CameraTutorTriggered();
        }
    }
    void CameraTutorTriggered()
    {
        workOnce=true;
        FindObjectOfType<GameController>().ShowCameraTutor();
        Debug.Log("CameraTutorTriggered");
    }
}
