using System;
using Random = UnityEngine.Random;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileMapGenerator : MonoBehaviour {

	public TextAsset textFile;

	private int [] [] map;
	private int columns;
	private int rows;

	// mark empty space as -
	public GameObject [] floorTiles; // 0
	public GameObject wallBase; // 1 
	public GameObject wallMid; // 2
	public GameObject wallTop; // 3

	public GameObject[] sceneryBlocking; //4
	public GameObject[] sceneryNonBlocking; //5

	public Vector3 boardTranslate;
	public const float size = 8.0f/9.0f;

	// Use this for initialization
	void Start () {
		map = parseTextMap(textFile.text);
		buildMap();
	}

	int [] [] parseTextMap(String textMap){
        string[] lines = System.Text.RegularExpressions.Regex.Split(textMap, "\r*\n");

        char[][] charMap = new char[lines.Length-1][];

		for (int y=0; y< charMap.Length; y++){
			charMap[y] = lines[y].ToCharArray();
		}

        rows = charMap.Length;
		columns = charMap[0].Length;

		print(rows);
		print(columns);
		
		//for(int y = 0; y < charMap.Length; y++) {
		//	for(int x = 0; x < charMap[0].Length; x++) {
		//		print(charMap[y][x]);
		//	}
		//	print("\n");
		//}
		

        int[][] numMap = new int[rows][];

        for (int y=0; y<numMap.Length; y++){
            numMap[y] = new int[columns];
        }

        for (int y=0; y < rows; y++){
        	for (int x=0; x<columns; x++){
				if (charMap[y][x] != '-' && !char.IsWhiteSpace(charMap[y][x])){
                    Debug.Log(charMap[y][x].ToString());
					numMap[y][x] = int.Parse(charMap[y][x].ToString());
				}
				else {
					numMap[y][x] = -1;
				}
        	}
    	}
		return numMap;
	}

	private void buildMap(){
		// create & instantiate the tileMap gameObject
		GameObject tileMap = new GameObject("GeneratedTileMap");
		tileMap.AddComponent<TileMap>();
		tileMap.transform.position = boardTranslate;

		GameObject [,] tiles = new GameObject[rows, columns];

		GameObject toInstantiate = null;

		for(int x = 0; x < columns; x++) {
			for(int y = 0; y < rows; y++) {
				switch(map[y][x]) {
				case 0:
					toInstantiate = floorTiles[x % floorTiles.Length];
					break;
				case 1:
					toInstantiate = wallBase;
					break;
				case 2:
					toInstantiate = wallMid;
					break;
				case 3:
					toInstantiate = wallTop;
					break;
				case 4:
					toInstantiate = floorTiles[x % floorTiles.Length];
					break;
				case 5:
					toInstantiate = floorTiles[x % floorTiles.Length];
					break;
				default:
					toInstantiate = null;
					print("no obj at " + y + "," + x);
					break;
				}
				if(toInstantiate) {
					GameObject instance = Instantiate(toInstantiate, 
						new Vector3(size*x, size*-y + 
							((map[y][x] == 1 || map[y][x] == 2 || map[y][x] == 3  ) ? size*-0.25f : 0),
							0.0f), Quaternion.identity) as GameObject;
					instance.transform.SetParent(tileMap.transform);
					tiles[y,x] = instance;
					tiles[y, x].AddComponent<Tile>();


					if (map[y][x] == 4 || map[y][x] == 5){
						GameObject sceneryItem;
						if(map[y][x] == 4) {
							sceneryItem = Instantiate(sceneryBlocking[Random.Range(0, sceneryBlocking.Length - 1)]);
						}
						else {
							sceneryItem = Instantiate(sceneryNonBlocking[Random.Range(0, sceneryBlocking.Length - 1)]);
						}
						sceneryItem.transform.SetParent(instance.transform, false);
						((Tile)tiles[y, x].GetComponent<Tile>()).setSceneryObject(sceneryItem);
					}
				}
			}
		}
		TileMap t = tileMap.GetComponent<TileMap>() as TileMap;
		//t.setTileSize(size);
		t.setTiles(tiles);
		/**/
	}

	public Vector2 getBoardTranslate(){
		return boardTranslate;
	}

	// Update is called once per frame
	void Update () {
		
	}
}
