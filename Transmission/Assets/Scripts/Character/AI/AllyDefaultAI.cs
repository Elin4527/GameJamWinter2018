﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDefaultAI : AIBase {

    public override Vector2 frameInput()
    {
        Vector2Int target = LevelManager.instance().current().getGoalPoint();
        if (target.x >= 0 && target.y >= 0)
        {
            Vector2 dest = character.getTileMap().convertTileCoords(target);
            return pathTo(dest);
        }
        return Vector2.zero;
    }

    public override AIBase fixedLogicTick()
    {
        EnemyCharacter e = queryInRange<EnemyCharacter>();
        if (e != null)
        {
            return new AttackingAI(e);
        }

        FriendlyItem i = queryInRange<FriendlyItem>();
        if(i != null)
        {
            return new CollectItemAI(i);
        }

        return null;
    }

    public override bool isValid()
    {
        return true;
    }

    public override void logicTick()
    {
        return;
    }
}
