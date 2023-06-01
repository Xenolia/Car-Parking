using UnityEngine;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    void Restart()
    {
        SceneManager.LoadScene(0);
    }
}
