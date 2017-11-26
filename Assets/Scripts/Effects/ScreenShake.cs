using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ScreenShake : MonoBehaviour {

    //public delegate void ScreenShakeEvent(float intensity, float duration);
    public delegate void ScreenShakeEvent(float intensityModifier);
    public static ScreenShakeEvent onScreenShake;
    
    void Start()
    {
        onScreenShake += Shake;
    }

    void Shake(float intensity)
    {
        DOTween.Shake(() => transform.position, x => transform.position = x, 0.5f, 0.1f * intensity, 15, 20, true); 
    }

    private void OnDisable()
    {
        onScreenShake -= Shake;
    }

}
