using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {


	public GameObject timelineExecutor;
	public GameObject tileMap;

	private GameObject [] players;

	// Use this for initialization
	void Start () {
		Instantiate(tileMap).transform.parent = transform;
		Instantiate(timelineExecutor).transform.parent = transform;
	}
		
	public void loadPlayers(GameObject[] players){
		this.players = players;
		// perform init tasks - settings transforms, restoring hp, etc.
	}

	public Timeline timeline(){
		return timelineExecutor.GetComponent<Timeline>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
