using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseParticle : MonoBehaviour {
    [SerializeField] private GameObject _particle;

    [SerializeField] private TrailRenderer _trail;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Input.GetMouseButton(0))
        {
            _particle.SetActive(true);
            _particle.transform.position = mousePos;
        }
        else if(!Input.GetMouseButton(0))
        {
            _trail.Clear();
        }
    }
}
