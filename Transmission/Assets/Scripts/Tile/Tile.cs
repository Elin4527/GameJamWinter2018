using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour {

	public GameObject sceneryObject;
	private GameObject item;
	public Vector2Int tileCoord;

	public void setItem(GameObject item){
		this.item = item;
	}

	public GameObject getItem (){
		return item;
	}

	public void setSceneryObject(GameObject sceneryObject){
		this.sceneryObject = sceneryObject;
	}

	public GameObject getSceneryObject(){
		return sceneryObject;
	}

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
	}
}
