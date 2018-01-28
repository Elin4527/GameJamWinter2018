using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapObject : MonoBehaviour {

    private TileMap tileMap;

    public void setTileMap(TileMap map)
    {
        tileMap = map;
    }

    public TileMap getTileMap()
    {
        return tileMap;
    }

    public int getSortValue()
    {
        Vector2Int pos1 = tileMap.getTileCoords(transform.position);
        return pos1.x * tileMap.getCols() + pos1.y;
    }

    public void OnDestroy()
    {
        LevelManager.instance().current().removeLevelEntity(this);
    }
}
