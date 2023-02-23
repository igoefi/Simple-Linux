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
        Setup();
    }

    public void SetFXMusic(float volume)
    {
        _mixer.audioMixer.SetFloat("FXVolume", GetNormalVolume(volume));
        PlayerPrefs.SetFloat("FXVolume", volume);
    }
    public void SetBGMusic(float volume)
    {
        _mixer.audioMixer.SetFloat("MusicVolume", GetNormalVolume(volume));
        PlayerPrefs.SetFloat("MusicVolume", volume);
    }

    private float GetNormalVolume(float volume)
    {
        if (volume <= 0.01f)
            return -80;
        else
            return Mathf.Lerp(-40, 0, volume);
    }

    public void Setup()
    {
        FXSlider.value = PlayerPrefs.GetFloat("FXVolume", 1);
        BGMSlider.value = PlayerPrefs.GetFloat("MusicVolume", 1);

        gameObject.SetActive(false);
    }

}
