using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindNode {
    public PathfindNode(Vector2Int pos)
    {
        index = pos;
        parent = null;
        cachedCost = 0;
        weight = 0;
    }

    public Vector2Int index;
    public PathfindNode parent;
    public float cachedCost;
    public float weight;
}
