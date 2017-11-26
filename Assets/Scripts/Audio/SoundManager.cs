using System.Collections;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Instance of this script.
    private static SoundManager s_Instance = null;

    // Instantiates a new SoundManager if one cannot be found.
    public static SoundManager instance
    {
        get
        {
            if (s_Instance == null)
            {
                s_Instance = FindObjectOfType(typeof(SoundManager)) as SoundManager;
            }


            if (s_Instance == null)
            {
                GameObject obj = new GameObject("SoundManager");
                s_Instance = obj.AddComponent(typeof(SoundManager)) as SoundManager;
            }

            return s_Instance;
        }

        set { }
    }
    
    // Removes the instance of the SoundManager 
    void OnApplicationQuit()
    {
        s_Instance = null;
    }
    
    // Loads the sound clips from the Resources/Audio folder so they can be used.
    // Also makes sure the sound manager persists through every scene.
    private void Awake()
    {
        if (s_Instance != null && s_Instance != this)
        {
            Destroy(gameObject);
        }

        s_Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Plays the given at default volume and pitch if no volume and pitch are given.
    /// </summary>
    /// <param name="clipToPlay">The clip that will be played.</param>
    /// <param name="volume">The volume at which the clip will be played.</param>
    public void PlaySound(AudioClip clipToPlay, float volume = 1f)
    {
        StartCoroutine(SimultaneousSound(clipToPlay, volume));
    }

    /// <summary>
    /// Plays the given at default volume and pitch if no volume and pitch are given.
    /// Plays simultaneously with other sounds.
    /// </summary>
    /// <param name="clipToPlay">The clip that will be played.</param>
    /// <param name="volume">The volume at which the clip will be played.</param>
    private IEnumerator SimultaneousSound(AudioClip clipToPlay, float volume = 1f)
    {
        AudioSource tempAS = gameObject.AddComponent<AudioSource>();
        tempAS.clip = clipToPlay;
        tempAS.volume = volume;
        tempAS.Play();
        yield return new WaitForSeconds(clipToPlay.length);
        Destroy(tempAS);
    }
}