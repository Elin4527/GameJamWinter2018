using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDefaultAI : AIBase {

    Vector2 dest;
    bool initialized = false;

    public override void startUp()
    {
        dest = character.transform.position;
    }

    public override Vector2 frameInput()
    {
        Vector2Int target = LevelManager.instance().current().getGoalPoint();
        if (target.x >= 0 && target.y >= 0)
        {
            dest = character.getTileMap().convertTileCoords(target);
            return pathTo(dest);
        }
        else
        if ((dest - (Vector2)character.transform.position).magnitude < 0.1f || !initialized)
        {
            initialized = true;
            bool flag = false;
            while (!flag)
            {
                UnityEngine.Random.InitState((int)System.DateTime.Now.Ticks);
                dest = character.getCharacterStats().getVision() / 2.0f * UnityEngine.Random.insideUnitCircle;
                Vector2Int tileCoords = character.getTileMap().getTileCoords(dest);

                GameObject g = character.getTileMap().getTile(tileCoords);

                if (g == null || g.tag == "Wall")
                {
                    continue;
                }

                flag = true;
                for (int i = 0; i < g.transform.childCount; i++)
                {
                    if (g.transform.GetChild(i).tag == "Wall")
                    {
                        flag = false;
                        break;
                    }
                }

                flag = (dest - (Vector2)character.transform.position).magnitude >= 0.1f;
            }
        }
        return pathTo(dest);
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
