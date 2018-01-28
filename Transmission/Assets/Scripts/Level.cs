using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour {

    public Vector2Int spawnPoint;
    public Vector2Int goalPoint = new Vector2Int(-1, -1);
	public Timeline timelineExecutor;
	public TileMapGenerator tileMap;

    public TileMap tileMapRef;

	private List<AllyCharacter> players;

    public List<MapObject> levelEntities;
    private GameObjectSorter objectSorter;


    // Use this for initialization
    void Start () {

    }


    public List<T> getObjectsInRange<T>(Vector2 topLeft, Vector2 bottomRight)
    {
        List<T> results = new List<T>();

        Vector2Int tlCoords = tileMapRef.getTileCoords(topLeft);
        Vector2Int brCoords = tileMapRef.getTileCoords(bottomRight);

        for (int x = tlCoords.x; x <= brCoords.x; x++)
        {
            int lowerSortVal = x * tileMapRef.getCols() + tlCoords.y;
            int upperSortVal = x * tileMapRef.getCols() + brCoords.y;
            int first = levelEntities.FindIndex(i => i.getSortValue() >= lowerSortVal);
            if (first == -1) continue;


            int last = levelEntities.FindLastIndex(i => i.getSortValue() <= upperSortVal);

            for (int i = first; i <= last; i++)
            {
                T t = levelEntities[i].GetComponent<T>();
                if(t != null)
                {
                    results.Add(t);
                }
            }
        }

        return (results.Count > 0) ? results : null;
    }

    public void init() {
        objectSorter = new GameObjectSorter();
        levelEntities = new List<MapObject>();
        TileMapGenerator gen = Instantiate(tileMap);
        tileMapRef = gen.run();
        tileMapRef.transform.parent = transform;
        Instantiate(timelineExecutor).transform.parent = transform;
    }

    public Vector2Int getSpawnPoint()
    {
        return spawnPoint;
    }

    public Vector2Int getGoalPoint()
    {
        return goalPoint;
    }

    public void addLevelEntity(MapObject g, Vector2Int index)
    {
        levelEntities.Add(g);
        g.transform.parent = tileMapRef.transform;
        g.transform.position = tileMapRef.convertTileCoords(index);

        BaseCharacter c = g.GetComponent<BaseCharacter>();
        if(c != null)
        {
            c.setTileMap(tileMapRef.GetComponent<TileMap>());
        }
    }

    public void removeLevelEntity(MapObject o)
    {
        levelEntities.Remove(o);
    }

	public void loadPlayers(List<AllyCharacter> players){
		this.players = players;

        foreach(AllyCharacter a in players)
        {
            addLevelEntity(a, spawnPoint);
        }
		// perform init tasks - settings transforms, restoring hp, etc.
	}

	public Timeline timeline(){
		return timelineExecutor;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void LateUpdate()
    {
        levelEntities.Sort(objectSorter);
    }
}
