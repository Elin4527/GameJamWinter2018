﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathfindQueue {

    private List<PathfindNode> data;
    public PathfindQueue()
    {
        data = new List<PathfindNode>();
    }

    public PathfindNode peek()
    {
        return (data.Count > 0) ? data[0] : null;
    }

    public PathfindNode findNode(int x, int y)
    {
        for(int i = 0; i < data.Count; i++)
        {
            if(data[i].x == x && data[i].y == y)
            {
                return data[i];
            }
        }
        return null;
    }

    public void insertNode(PathfindNode node)
    {
        data.Insert(binarySearchEnd(node), node);
    }

    public void removeNode(PathfindNode node)
    {
        int end = binarySearchEnd(node);
        for(int i = binarySearchStart(node); i < end; i++)
        {
            if(data[i] == node)
            {
                data.RemoveAt(i);
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
        int max = data.Count - 1;
        while (min <= max)
        {
            int mid = (min + max) / 2;
            if (node.weight == data[mid].weight)
            {
                while (node.weight == data[mid].weight && mid >= data.Count)
                {
                    mid--;
                }
                return mid + 1;
            }
            else if (node.weight < data[mid].weight)
            {
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }
        return min;
    }

    private int binarySearchEnd(PathfindNode node)
    {
        int min = 0;
        int max = data.Count - 1;
        while(min <= max)
        {
            int mid = (min + max) / 2;
            if (node.weight == data[mid].weight)
            {
                while (node.weight == data[mid].weight && mid < data.Count)
                {
                    mid++;
                }
                return mid;
            }
            else if (node.weight < data[mid].weight)
            {
                max = mid - 1;
            }
            else
            {
                min = mid + 1;
            }
        }
        return min;
    }
}