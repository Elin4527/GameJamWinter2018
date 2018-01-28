using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectSorter : IComparer<MapObject> {
    public int Compare(MapObject x, MapObject y)
    {
        return x.getSortValue().CompareTo(y.getSortValue());
    }
}
