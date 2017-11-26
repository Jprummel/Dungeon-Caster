using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSettings : MonoBehaviour {

    [SerializeField] private int _settingsPanelIndex;
	void Update () {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePanel.onPanelToggle(_settingsPanelIndex);
        }
	}
}
