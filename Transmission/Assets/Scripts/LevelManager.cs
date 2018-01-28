using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {


	// keep track of our singleton
	private static LevelManager inst = null;

	public  static LevelManager instance(){
		return inst;
	}

	public Level[] levels;
	public AllyCharacter [] players;
	private Level instantiatedLevel;
    private List<AllyCharacter> instantiatedPlayers;

	private int index = 0;

	// when we're instantiated and there is an existing level manager - delete
	void Start(){
		if (!inst) {
			inst = this;
		} else if (inst != this) {
			Destroy (gameObject);
		}

        instantiatedPlayers = new List<AllyCharacter>();
		foreach (AllyCharacter p in players){
            instantiatedPlayers.Add(Instantiate(p));
		}
		buildLevel(index);
		//TileMap t = current().tileMap.GetComponent<TileMap>();
		//print(t.getTileCoords(new Vector2(-11.5f, 18.7f)));
		//print(t.getTileCoords(new Vector2(-10.5f, 18.9f)));
		//print(t.getTileCoords(new Vector2(3.56f, -1.2f)));
	}
		

	void buildLevel(int index){
		instantiatedLevel = Instantiate(levels[index]);
		instantiatedLevel.transform.parent = transform;
        instantiatedLevel.init();
		instantiatedLevel.loadPlayers(instantiatedPlayers);
	}

	void nextLevel(){
		Destroy (instantiatedLevel);
		index++;
		if (index < levels.Length) {
			buildLevel (index);
		} else {
			gameOver();
		}
	}

	public Level current(){
		return instantiatedLevel.GetComponent<Level>();
	}

	public Timeline currentTimeline(){
		return current().timeline();
	}

	void gameOver(){}
	
	// Update is called once per frame
	void Update () {
		
	}

	// needs work
	public Vector2 convertTileCoords(Vector2 tileCoords){
		return new Vector3();
	}
}
