using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetter : MonoBehaviour
{
    [SerializeField] AudioMixerGroup _mixer;

    [SerializeField] Slider FXSlider;
    [SerializeField] Slider BGMSlider;

    private void Start()
    {
        FXSlider.value = PlayerPrefs.GetFloat("FXVolume", 1);
        BGMSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);
    }

    public void SetFXMusic(float volume)
    {
        _mixer.audioMixer.SetFloat("FXVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("FXVolume", volume);
    }
    public void SetBGMusic(float volume)
    {
        _mixer.audioMixer.SetFloat("MusicVolume", Mathf.Lerp(-80, 0, volume));
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }
}
