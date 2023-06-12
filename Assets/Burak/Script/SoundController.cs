using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [SerializeField] Sprite soundOnImage;
    [SerializeField] Sprite soundOffImage;
    [SerializeField] Button soundButton;

    [SerializeField] Sprite musicOnImage;
    [SerializeField] Sprite musicOffImage;
    [SerializeField] Button musicButton;


    [SerializeField] Slider musicSlider;
    [SerializeField] float musicValue;
    [SerializeField] Slider soundSlider;
    [SerializeField] float soundValue;

    [SerializeField] AudioSource[] musics;
    [SerializeField] AudioSource[] sounds;

    [SerializeField] GameObject settingsPanel;
    private void Awake()
    {
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
        StartCoroutine(CheckSound());
    }
    public void MusicButton()
    {
        if(musicValue>0)
        {
            musicValue = 0;
            musicSlider.value = 0f;
            PlayerPrefs.SetFloat("Music", 0);
            musicButton.GetComponent<Image>().sprite = musicOffImage;
        }
        else
        {
            musicValue = 1;
            musicSlider.value = 1f;
             PlayerPrefs.SetFloat("Music", 1);
            musicButton.GetComponent<Image>().sprite = musicOnImage;

        }
        UpdateVolumes();

    }
    public void SoundButton()
    {
        if (soundValue > 0)
        {
            soundValue = 0;
            soundSlider.value = 0f;
            PlayerPrefs.SetFloat("Sound", 0);
            soundButton.GetComponent<Image>().sprite = soundOffImage;

        }
        else
        {
            soundValue = 1;
            soundSlider.value = 1f;
            PlayerPrefs.SetFloat("Sound", 1);
            soundButton.GetComponent<Image>().sprite = soundOnImage;

        }
        UpdateVolumes();
    }
    /*
    void MuteSound()
    {
        soundButton.GetComponent<Image>().sprite = soundOffImage;
    }
    void MuteMusic()
    {
        musicButton.GetComponent<Image>().sprite = musicOffImage;

    }
    */
    IEnumerator CheckSound()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            UpdateVolumes();
        }
    }
    public void EnableSettingsPanel()
    {
        if(settingsPanel.activeSelf)
        {
            settingsPanel.SetActive(false);
            Time.timeScale = 1f;

        }


        else
        {
            settingsPanel.SetActive(true);
            Time.timeScale = 0f;

        }

    }
    public void DisableSettingsPanel()
    {
        settingsPanel.SetActive(false);
        Time.timeScale = 1f;

    }
    void UpdateUI()
    {
        musicSlider.value = musicValue = PlayerPrefs.GetFloat("Music",1f);

        soundSlider.value = soundValue = PlayerPrefs.GetFloat("Sound",1f);


        if (musicValue > 0)
        {
            musicButton.GetComponent<Image>().sprite = musicOnImage;

        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicOffImage;

        }


        if (soundValue > 0)
        {
            soundButton.GetComponent<Image>().sprite = soundOnImage;

        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOffImage;

        }
        UpdateVolumes();
    }
  public  void SliderValueChanged()
    {
        musicValue = musicSlider.value;
        soundValue = soundSlider.value;
  
        PlayerPrefs.SetFloat("Sound", soundSlider.value);
        PlayerPrefs.SetFloat("Music", musicSlider.value);
        if (soundValue == 0f)
        {
            soundButton.GetComponent<Image>().sprite = soundOffImage;

        }
        else
        {
            soundButton.GetComponent<Image>().sprite = soundOnImage;

        }

        if (musicValue == 0f)
        {
            musicButton.GetComponent<Image>().sprite = musicOffImage;

        }
        else
        {
            musicButton.GetComponent<Image>().sprite = musicOnImage;

        }

        UpdateVolumes();
    }
    void UpdateVolumes()
    {
        foreach (var item in sounds)
        {
            item.volume = PlayerPrefs.GetFloat("Sound", 1f);
        }
        foreach (var item in musics)
        {
            item.volume = PlayerPrefs.GetFloat("Music", 1f);
        }
    }

}
