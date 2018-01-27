using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding {

    private PathfindQueue open;
    private PathfindQueue closed;
    private int destX, destY;

    public Pathfinding()
    {
        open = new PathfindQueue();
        closed = new PathfindQueue();
    }

    public List<GameObject> pathFindTo(Vector2 origin, Vector2 dest)
    {
        open.clear();
        closed.clear();

        return null;
    }
}
