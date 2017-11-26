using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class ScreenFader : MonoBehaviour {

    public delegate void ScreenFadeEvent(float alpha, float fadeDuration);
    public static ScreenFadeEvent onScreenFade;

    [SerializeField]private Image   _fullScreenFadeImage;

    void Awake () 
    {
        onScreenFade += Fade;
        onScreenFade(0, 3);
    }

    public void Fade(float alpha, float fadeDuration)
    {
        if (_fullScreenFadeImage != null)
        {
            _fullScreenFadeImage.DOFade(alpha, fadeDuration);
        }
    }

    private void OnDisable()
    {
        onScreenFade -= Fade;
    }
}
