using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    [SerializeField] GameObject[] levels;
    public int Level;
    private void Awake()
    {
        if(PlayerPrefs.HasKey("Level"))
        {

        }
    }
}
