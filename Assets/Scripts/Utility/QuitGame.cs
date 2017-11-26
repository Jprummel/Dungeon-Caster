using System.Collections;
using UnityEngine;

public class QuitGame : MonoBehaviour {

    public void Quit()
    {
        StartCoroutine(QuitRoutine());
    }

    IEnumerator QuitRoutine()
    {
        ScreenFader.onScreenFade(1, 1.5f);
        yield return new WaitForSeconds(1.6f);
        Application.Quit();
    }
}
