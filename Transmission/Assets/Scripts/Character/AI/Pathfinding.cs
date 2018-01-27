using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding {

    private PathfindQueue open;
    private PathfindQueue closed;
    Vector2Int end;
    TileMap tileMap;

    public Pathfinding()
    {
        open = new PathfindQueue();
        closed = new PathfindQueue();
    }

    public List<GameObject> pathFindTo(Vector2 origin, Vector2 dest, TileMap map)
    {
        tileMap = map;
        open.clear();
        closed.clear();

        float d1Cost = map.getTileSize();
        float d2Cost = Mathf.Sqrt(d1Cost * d1Cost * 2);

        Vector2Int start = map.getTileCoords(origin);
        end = map.getTileCoords(dest);

        

        open.insertNode(new PathfindNode(start));
        while(open.size() > 0)
        {
            PathfindNode currNode = open.pop();
            closed.insertNode(currNode);
            if (currNode.index == end)
                break;

            for (int x = -1; x <= 1; x++)
            {
                for (int y = -1; y <= 1; y++)
                {
                    if (x == 0 && y == 0)
                    {
                        continue;
                    }

                    Vector2Int neighbor = currNode.index + new Vector2Int(x, y);
                    if(neighbor.x < 0 || neighbor.x >= map.getCols() || neighbor.y < 0 || neighbor.y >= map.getRows())
                    {
                        continue;
                    }

                    GameObject g = map.getTile(neighbor);
                    if(g == null || g.tag == "Wall")
                    {
                        continue;
                    }

                    float cost = (x == 0 || y == 0) ? d1Cost : d2Cost;
                    float currCost = currNode.cachedCost + cost;

                    PathfindNode n = open.findNode(neighbor);
                    if(n != null && (currCost < n.cachedCost))
                    {
                        open.removeNode(n);
                    }

                    n = closed.findNode(neighbor);
                    if(n != null && (currCost < n.cachedCost))
                    {
                        closed.removeNode(n);
                    }

                    if(open.findNode(neighbor) == null && closed.findNode(neighbor) == null)
                    {
                        n = new PathfindNode(neighbor);
                        n.parent = currNode;
                        n.weight = calculateWeight(neighbor);
                        open.insertNode(n);
                    }

                }
            }
        }
        if (closed.size() > 0)
        {
            List<GameObject> path = new List<GameObject>();
            PathfindNode n = closed.pop();
            while (n.parent != null)
            {
                path.Insert(0, tileMap.getTile(n.index));
                n = n.parent;
            }
            return path;
        }
        return null;
    }

    private float calculateWeight(Vector2Int pos)
    {
        Vector2 curr = tileMap.convertTileCoords(pos);
        Vector2 dest = tileMap.convertTileCoords(end);

        return (dest - curr).magnitude;
    }
}
