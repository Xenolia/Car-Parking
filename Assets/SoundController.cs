using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] float musicValue;
    [SerializeField] Slider soundSlider;
    [SerializeField] float soundValue;

    private void Awake()
    {
       if( PlayerPrefs.HasKey("Sound"))
        {
            soundValue = PlayerPrefs.GetFloat("Sound");
        }
        if (PlayerPrefs.HasKey("Sound"))
        {
            musicValue = PlayerPrefs.GetFloat("Music");
        }
        UpdateUI();
    }

   
    void UpdateUI()
    {
        musicSlider.value = musicValue;
        soundSlider.value = soundValue;
    }

   
}
