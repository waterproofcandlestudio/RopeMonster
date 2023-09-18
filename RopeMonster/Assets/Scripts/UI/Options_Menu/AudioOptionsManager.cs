using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class AudioOptionsManager : MonoBehaviour
{
    [SerializeField] AudioMixer audioMixer;

    // Valores de los sliders del menú opciones
    [SerializeField] Slider musicVolumeSlider;
    [SerializeField] Slider effectsVolumeSlider;
    [SerializeField] Slider uIVolumeSlider;
    TextMeshProUGUI musicVolume_Slider_Text;
    TextMeshProUGUI effectsVolume_Slider_Text;
    TextMeshProUGUI uIVolume_Slider_Text;

    [SerializeField] float defaultSfxVolume = 0f;
    [SerializeField] float defaultMusicVolume = 0f; 
    [SerializeField] float defaultUiVolume = 0f;

    void Awake()
    {
        GetReferences();
        InitializeVariables();
    }

    public void SetMusicVolume(float volume)
    {
        volume = musicVolumeSlider.value;
        audioMixer.SetFloat("musicVolume", volume);
        PlayerPrefs.SetFloat("musicVolume", volume);
        musicVolume_Slider_Text.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("musicVolume")).ToString();
    }
    public void SetSfxVolume(float volume)
    {
        volume = effectsVolumeSlider.value;
        audioMixer.SetFloat("sfxVolume", volume);
        PlayerPrefs.SetFloat("sfxVolume", volume);
        effectsVolume_Slider_Text.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("sfxVolume")).ToString();
    }
    public void SetUiVolume(float volume)
    {
        volume = uIVolumeSlider.value;
        audioMixer.SetFloat("uiVolume", volume);
        PlayerPrefs.SetFloat("uiVolume", volume);
        uIVolume_Slider_Text.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("uiVolume")).ToString();
    }
    public void Reset_AudioOptions()
    {
        musicVolumeSlider.value = defaultMusicVolume;
        audioMixer.SetFloat("musicVolume", defaultMusicVolume);
        PlayerPrefs.SetFloat("musicVolume", defaultMusicVolume);

        effectsVolumeSlider.value = defaultSfxVolume;
        audioMixer.SetFloat("sfxVolume", defaultSfxVolume);
        PlayerPrefs.SetFloat("sfxVolume", defaultSfxVolume);

        uIVolumeSlider.value = defaultUiVolume;
        audioMixer.SetFloat("uiVolume", defaultUiVolume);
        PlayerPrefs.SetFloat("uiVolume", defaultUiVolume);
    }
    void GetReferences()
    {
        musicVolume_Slider_Text = musicVolumeSlider.GetComponentInChildren<TextMeshProUGUI>();
        effectsVolume_Slider_Text = effectsVolumeSlider.GetComponentInChildren<TextMeshProUGUI>();
        uIVolume_Slider_Text = uIVolumeSlider.GetComponentInChildren<TextMeshProUGUI>();
    }

    void InitializeVariables()
    {
        LoadAudioSettings();
        InitializeSliderPercentajes_Text();
    }
    void LoadAudioSettings()         // Paso los valores de las opciones al "PlayerPrefs" para q no se pierdan con el cambio de escena
    {
        if (PlayerPrefs.HasKey("musicVolume"))
            musicVolumeSlider.value = PlayerPrefs.GetFloat("musicVolume");
        else
        {
            PlayerPrefs.SetFloat("musicVolume", defaultMusicVolume);
            musicVolumeSlider.value = defaultMusicVolume;
        }
        //
        if (PlayerPrefs.HasKey("sfxVolume"))
            effectsVolumeSlider.value = PlayerPrefs.GetFloat("sfxVolume");
        else
        {
            PlayerPrefs.SetFloat("sfxVolume", defaultSfxVolume);
            effectsVolumeSlider.value = defaultSfxVolume;
        }
        //
        if (PlayerPrefs.HasKey("uiVolume"))
            uIVolumeSlider.value = PlayerPrefs.GetFloat("uiVolume");
        else
        {
            PlayerPrefs.SetFloat("uiVolume", defaultUiVolume);
            uIVolumeSlider.value = defaultUiVolume;
        }
    }

    void InitializeSliderPercentajes_Text()
    {
        musicVolume_Slider_Text.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("musicVolume")).ToString();
        effectsVolume_Slider_Text.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("sfxVolume")).ToString();
        uIVolume_Slider_Text.text = Mathf.RoundToInt(PlayerPrefs.GetFloat("uiVolume")).ToString();
    }
}
