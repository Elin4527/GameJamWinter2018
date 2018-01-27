using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

	private GameObject [,] tiles;
	// Use this for initialization
	void Start () {}

	public void setTiles(GameObject [,] tiles){
		this.tiles = tiles;
	}

	public GameObject getTile(int y, int x){
		return tiles[y,x];
	}

	// Update is called once per frame
	void Update () {
		
	}
}
