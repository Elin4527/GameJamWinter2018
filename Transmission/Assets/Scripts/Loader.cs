using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loader : MonoBehaviour {

	public GameObject levelManager;

	// Use this for initialization
	void Start () {
		if (!LevelManager.instance()) {
			Instantiate(levelManager);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
