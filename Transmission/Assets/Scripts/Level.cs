using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public Vector2Int spawnPoint;
	public Timeline timelineExecutor;
	public TileMap tileMap;

    private GameObject tileMapRef;

	private List<AllyCharacter> players;

    public List<GameObject> levelEntities;


    // Use this for initialization
    void Start () {

	}

    public void init()
    {
        levelEntities = new List<GameObject>();
        tileMapRef = Instantiate(tileMap).gameObject;
        tileMapRef.transform.parent = transform;
        Instantiate(timelineExecutor).transform.parent = transform;
    }

    public void addLevelEntity(GameObject g)
    {
        levelEntities.Add(g);
        g.transform.parent = tileMapRef.transform;

        BaseCharacter c = g.GetComponent<BaseCharacter>();
        if(c != null)
        {
            c.setTileMap(tileMapRef.GetComponent<TileMap>());
        }
    }

	public void loadPlayers(List<AllyCharacter> players){
		this.players = players;

        Vector2 spawn = tileMap.convertTileCoords(spawnPoint);
        foreach(AllyCharacter a in players)
        {
            a.transform.position = spawn;
            addLevelEntity(a.gameObject);
        }
		// perform init tasks - settings transforms, restoring hp, etc.
	}

	public Timeline timeline(){
		return timelineExecutor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
