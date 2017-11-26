using System.Collections.Generic;
using UnityEngine;

public class SoundsDatabase : MonoBehaviour
{
    [SerializeField]private List<AudioClip> _audioClips;

    public static Dictionary<string, AudioClip> AudioClips = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        for (int i = 0; i < _audioClips.Count; i++)
        {
            if (!AudioClips.ContainsKey(_audioClips[i].name))
            {
                AudioClips.Add(_audioClips[i].name, _audioClips[i]);
            }
        }
    }
}