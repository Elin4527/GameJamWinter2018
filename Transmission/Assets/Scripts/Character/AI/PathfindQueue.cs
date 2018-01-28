using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindQueue {

    private List<PathfindNode> data;
    public PathfindQueue()
    {
        data = new List<PathfindNode>();
    }

    public int size()
    {
        return data.Count;
    }

    public PathfindNode peek()
    {
        return (data.Count > 0) ? data[0] : null;
    }

    public PathfindNode pop()
    {
        PathfindNode p = null;
        if(data.Count > 0)
        {
            p = data[0];
            data.Remove(p);
        }
        return p;
    }

    public PathfindNode findNode(Vector2Int pos)
    {
        for(int i = 0; i < data.Count; i++)
        {
            if(data[i].index == pos)
            {
                return data[i];
            }
        }
        return null;
    }

    public void insertNode(PathfindNode node)
    {
        if (data.Count == 0)
        {
            data.Add(node);
        }
        else
        {
            data.Insert(binarySearchStart(node), node);
        }
    }

    public void removeNode(PathfindNode node)
    {
        int end = binarySearchEnd(node);
        for(int i = binarySearchStart(node); i < end; i++)
        {
            if(data[i] == node)
            {
                data.RemoveAt(i);
                break;
            }
        }
    }

    public void clear()
    {
        data.Clear();
    }

    private int binarySearchStart(PathfindNode node)
    {
        int min = 0;
        int max = data.Count;
        while (min < max)
        {
            int mid = (min + max) / 2;
            if (data[mid].weight < node.weight)
            {
                min = mid + 1;
            }
            else {
                max = mid;
            }
        }
        return min;
    }

    private int binarySearchEnd(PathfindNode node)
    {
        int min = 0;
        int max = data.Count;
        while(min < max)
        {
            int mid = (min + max) / 2;
            if (data[mid].weight > node.weight)
            {
                max = mid;
            }
            else
            {
                min = mid + 1;
            }
        }
        return min;
    }
}
