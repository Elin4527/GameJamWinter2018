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
}
