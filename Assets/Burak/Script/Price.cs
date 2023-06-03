using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Price : MonoBehaviour
{
    public bool Locked=false;

    public int CarPrice = 100;

    private void Awake()
    {
        CheckIfUnlocked();
       
    }
    public void Unlock()
    {
        PlayerPrefs.SetInt(transform.name,1);
        Locked = false;
    }
    public void Lock()
    {
        Locked = true;
    }
    void CheckIfUnlocked()
    {
        if (PlayerPrefs.HasKey(transform.name))
        {
            if (PlayerPrefs.GetInt(transform.name) == 1)
            {

                Unlock();
            }
            else
            {
                Lock();   
            }
        }
    }
}
