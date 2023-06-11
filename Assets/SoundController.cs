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

    [SerializeField] AudioSource[] musics;
    [SerializeField] AudioSource[] sounds;

    [SerializeField] GameObject settingsPanel;
    private void Awake()
    {
        Debug.LogError("wrong");
       if( PlayerPrefs.HasKey("Sound"))
        {
            soundValue = PlayerPrefs.GetFloat("Sound");
        }
        else
        {
            soundValue = 1F;
            PlayerPrefs.SetFloat("Sound", soundValue);
        }
        if (PlayerPrefs.HasKey("Music"))
        {
            musicValue = PlayerPrefs.GetFloat("Music");
        }
        else
        {
            musicValue = 1F;
            PlayerPrefs.SetFloat("Music", musicValue);
        }

        UpdateUI();
        UpdateVolumes();
    }

   public void EnableSettingsPanel()
    {
        if(settingsPanel.activeSelf)
            settingsPanel.SetActive(false);
else
        settingsPanel.SetActive(true);

    }
    public void DisableSettingsPanel()
    {
        settingsPanel.SetActive(false);
    }
    void UpdateUI()
    {
        musicSlider.value = musicValue = PlayerPrefs.GetFloat("Music",1f);

        soundSlider.value = soundValue = PlayerPrefs.GetFloat("Sound",1f);
    }
  public  void SliderValueChanged()
    {
        musicValue = musicSlider.value;
        soundValue = soundSlider.value;
 
        PlayerPrefs.SetFloat("Sound", musicSlider.value);
        PlayerPrefs.SetFloat("Music", soundSlider.value);  
    }
    void UpdateVolumes()
    {
        foreach (var item in sounds)
        {
            item.volume = soundValue;
        }
        foreach (var item in musics)
        {
            item.volume = musicValue;
        }
    }

}
