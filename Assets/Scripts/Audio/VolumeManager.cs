using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeManager : MonoBehaviour {

    public delegate void VolumeChangeEvent();

    [SerializeField] private AudioMixer _masterMixer;
    [SerializeField] private Slider _masterSlider;
    [SerializeField] private Slider _musicSlider;
    [SerializeField] private Slider _SFXSlider;
    // Use this for initialization
    void Awake () {
        _masterMixer.SetFloat("", GameSettingsData.MasterVolume);
        _masterMixer.SetFloat("", GameSettingsData.MusicVolume);
        _masterMixer.SetFloat("", GameSettingsData.SFXVolume);

        _masterSlider.value = GameSettingsData.MasterVolume;
        _musicSlider.value = GameSettingsData.MusicVolume;
        _SFXSlider.value = GameSettingsData.SFXVolume;
    }
	
	// Update is called once per frame
	void Update () {
        _masterMixer.SetFloat("", GameSettingsData.MasterVolume);
    }


    //void VolumeChangeEvents() { }


}




//?????????????????????????????
