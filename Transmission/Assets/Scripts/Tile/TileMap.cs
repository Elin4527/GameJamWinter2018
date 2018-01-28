using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMap : MonoBehaviour {

	private float tileSize;
	private GameObject [,] tiles;

	// Use this for initialization
	void Start () {}

	public int getRows(){
		return tiles.GetLength(0);
	}

	public int getCols(){
		return tiles.GetLength(1);
	}

	/**
	 *  don't call this function
	 **/
	public void setTileSize(float size){
		this.tileSize = size;
	}

	public float getTileSize(){
		return tileSize;
	}

	/**
	 *  don't call this function
	 **/
	public void setTiles(GameObject [,] tiles){
		this.tiles = tiles;
	}

	public GameObject getTile(int x, int y){
        if (y >= 0 && y < getRows() && x >= 0 && x < getCols())
        {
            return tiles[y, x];
        }
        return null;
	}

    public GameObject getTile(Vector2Int coords)
    {
        if (coords.y >= 0 && coords.y < getRows() && coords.x >= 0 && coords.x < getCols())
        {
            return tiles[coords.y, coords.x];
        }
        return null;
    }

    /**
	 * produces tile corresponding to world coordinates
	 **/
    public GameObject getTile(Vector2 pos){
		Vector2Int tileCoords = getTileCoords(pos);
		return getTile(tileCoords.x, tileCoords.y);
	}

	/**
	 *  produces tileCoords from world coords
	 **/
	public Vector2Int getTileCoords(Vector2 pos){
		pos.x -= transform.position.x;
		pos.x -= transform.position.x;

		int x = (int)(pos.x / getTileSize() + 0.5f);
		int y = (int)(-pos.y / getTileSize() + 0.5f);

        //Debug.Log(pos + "produced x " + x + " y " + y);
		return new Vector2Int(x, y);
	}

    public Vector3 convertTileCoords(Vector2 tileCoords)
    {
        Vector3 boardTranslate = transform.position;

        Vector3 loc = new Vector3(tileCoords.x * getTileSize() + boardTranslate.x, - tileCoords.y * getTileSize() +  boardTranslate.y);

        return loc;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
