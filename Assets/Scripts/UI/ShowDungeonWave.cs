using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDungeonWave : MonoBehaviour {

    public delegate void UpdateWave(int currentWave, int maxWave);
    public static UpdateWave onWaveChange;

    private Text _waveText;

    private void OnEnable()
    {
        _waveText = GetComponent<Text>();
        onWaveChange += ShowWave;
    }

    void Start () {
        
        
	}

    void ShowWave(int currentWave,int maxWave)
    {
        _waveText.text = "Wave " + currentWave + " / " + maxWave;
    }

    private void OnDisable()
    {
        onWaveChange -= ShowWave;
    }
}
