using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ItemSpawnEvent : TimelineEvent {

    public Vector2Int tileCoords;
    public Item item;

    public ItemSpawnEvent(float time, Vector2Int tileCoords, Item item, bool delta = true)
        : base(time, delta)
    {
        this.tileCoords = tileCoords;
        this.item = item;
    }


    public override void execute()
    {
        Item i = UnityEngine.Object.Instantiate(item);
        LevelManager.instance().current().addLevelEntity(i, tileCoords);
    }
}
