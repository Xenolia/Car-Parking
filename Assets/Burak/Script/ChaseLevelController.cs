using UnityEngine;

public class ChaseLevelController : MonoBehaviour
{
    [SerializeField] GameObject chaseLevelPrefab;

    public void Init()
    {
        if (chaseLevelPrefab != null)
        {
            Instantiate(chaseLevelPrefab, Vector3.zero, Quaternion.identity);
        }
        else
        {
            Debug.LogWarning("ChaseLevelPrefab is not assigned in ChaseLevelController!");
        }
    }
}
