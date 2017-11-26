using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VolumeSettings : MonoBehaviour {

    [SerializeField] private AudioMixer _audioMixer;
    [SerializeField] private Slider _masterVolumeSlider;
    [SerializeField] private Slider _musicVolumeSlider;
    [SerializeField] private Slider _sfxVolumeSlider;
    // Use this for initialization
    void Start()
    {
        _audioMixer.SetFloat("MasterVolume", GameSettingsData.MasterVolume);
        _audioMixer.SetFloat("MusicVolume", GameSettingsData.MusicVolume);
        _audioMixer.SetFloat("SFXVolume", GameSettingsData.SFXVolume);

        _masterVolumeSlider.value = GameSettingsData.MasterVolume;
        _musicVolumeSlider.value = GameSettingsData.MusicVolume;
        _sfxVolumeSlider.value = GameSettingsData.SFXVolume;
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ChangeMasterVolume()
    {
        _audioMixer.SetFloat("MasterVolume", _masterVolumeSlider.value);
        GameSettingsData.MasterVolume = _masterVolumeSlider.value;
    }

    public void ChangeMusicVolume()
    {
        _audioMixer.SetFloat("MusicVolume", _musicVolumeSlider.value);
        GameSettingsData.MusicVolume = _musicVolumeSlider.value;
    }

    public void ChangeSFXVolume()
    {
        _audioMixer.SetFloat("SFXVolume", _sfxVolumeSlider.value);
        GameSettingsData.SFXVolume = _sfxVolumeSlider.value;
    }
}
