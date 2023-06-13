using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
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
    string musicKey = "Music";
    string soundKey = "Sound";

    private void Awake()
    {
        if (PlayerPrefs.HasKey(soundKey))
        {
            soundValue = PlayerPrefs.GetFloat(soundKey);

        }
        else
        {
            soundValue = 1f;
            PlayerPrefs.SetFloat(soundKey, soundValue);
        }

        if (PlayerPrefs.HasKey(musicKey))
        {
            musicValue = PlayerPrefs.GetFloat(musicKey);
        }
        else
        {
            musicValue = 1f;
            PlayerPrefs.SetFloat(musicKey, musicValue);
        }

        UpdateUI();
        UpdateVolumes();
        StartCoroutine(CheckSound());
    }
    private void OnDisable()
    {
        PlayerPrefs.SetFloat(soundKey, soundValue);
        PlayerPrefs.SetFloat(musicKey, musicValue);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Tab))
        {
            EnableSettingsPanel();
        }
    }
    public void MusicButton()
    {
        if (musicValue > 0)
        {
            musicValue = 0;
            musicSlider.value = 0f;
            PlayerPrefs.SetFloat(musicKey, 0);
            musicButton.GetComponent<Image>().sprite = musicOffImage;
        }
        else
        {
            musicValue = 1;
            musicSlider.value = 1f;
            PlayerPrefs.SetFloat(musicKey, 1);
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
            PlayerPrefs.SetFloat(soundKey, 0);
            soundButton.GetComponent<Image>().sprite = soundOffImage;

        }
        else
        {
            soundValue = 1;
            soundSlider.value = 1f;
            PlayerPrefs.SetFloat(soundKey, 1);
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
        if (settingsPanel.activeSelf)
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


    void ASD(float musicVal, float soundVal, [CallerMemberName] string callername = "")
    {
         musicSlider.value = musicVal;

        soundSlider.value = soundVal;
    }
    void UpdateUI()
    {
        ASD(musicValue, soundValue);



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
    public void SliderValueChanged()
    {
        musicValue = musicSlider.value;
        soundValue = soundSlider.value;

        PlayerPrefs.SetFloat(soundKey, soundValue);
        PlayerPrefs.SetFloat(musicKey, musicValue);
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
            item.volume = soundValue;
            //  item.volume = PlayerPrefs.GetFloat(soundKey, 1f);
        }
        foreach (var item in musics)
        {
            item.volume = musicValue;
            // item.volume = PlayerPrefs.GetFloat(musicKey, 1f);
        }

    }

}
