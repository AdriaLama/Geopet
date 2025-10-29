using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    [Header("Audio Mixer")]
    public AudioMixer audioMixer;

    [Header("Sliders")]
    public Slider musicSlider;
    public Slider sfxSlider;

    private void Start()
    {
        float musicValue = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        float sfxValue = PlayerPrefs.GetFloat("SFXVolume", 0.5f);

        
        musicSlider.value = musicValue;
        sfxSlider.value = sfxValue;

  
        SetMusicVolume(musicValue);
        SetSFXVolume(sfxValue);

       
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    public void SetMusicVolume(float value)
    {
      
        float volume = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1)) * 20;
        audioMixer.SetFloat("MusicVolume", volume);
        PlayerPrefs.SetFloat("MusicVolume", value);
        PlayerPrefs.Save();

    }

    public void SetSFXVolume(float value)
    {
        float volume = Mathf.Log10(Mathf.Clamp(value, 0.0001f, 1)) * 20;
        audioMixer.SetFloat("SFXVolume", volume);
        PlayerPrefs.SetFloat("SFXVolume", value);
        PlayerPrefs.Save();
    }
}
