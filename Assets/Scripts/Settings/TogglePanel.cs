using System.Collections.Generic;
using UnityEngine;

public class TogglePanel : MonoBehaviour
{

    public delegate void TogglePanelEvent(int panelIndex);
    public static TogglePanelEvent onPanelToggle;
    [SerializeField] private List<GameObject> _panels = new List<GameObject>();

    void Start()
    {
        onPanelToggle += TogglePanels;
    }

    public void TogglePanels(int panelIndex)
    {
        if (!GameState.IsGameOver && !GameState.IsDungeonDone)
        {
            for (int i = 0; i < _panels.Count; i++)
            {
                if (i != panelIndex)
                {
                    _panels[i].SetActive(false);
                }

                if (panelIndex == i)
                {
                    if (_panels[i].activeSelf == false)
                    {
                        _panels[i].SetActive(true);
                        GameState.IsPaused = true;
                    }
                    else if (_panels[i].activeSelf == true)
                    {
                        _panels[i].SetActive(false);
                        GameState.IsPaused = false;
                    }
                }
            }
        }
    }

    private void OnDisable()
    {
        onPanelToggle -= TogglePanels;
    }
}
