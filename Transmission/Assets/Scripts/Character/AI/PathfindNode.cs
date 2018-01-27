using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindNode {
    public PathfindNode(int x, int y)
    {
        this.x = x;
        this.y = y;
        parent = null;
        cachedCost = 0;
        weight = 0;
    }

    public int x;
    public int y;
    public PathfindNode parent;
    public float cachedCost;
    public float weight;
}
