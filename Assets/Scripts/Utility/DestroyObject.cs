using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObject : MonoBehaviour {
    
    [SerializeField] private float _destroyWaitTime;

    void Awake()
    {
        Destroy(this.gameObject,_destroyWaitTime);
    }
}
