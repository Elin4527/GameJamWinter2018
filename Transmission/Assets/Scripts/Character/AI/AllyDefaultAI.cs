using System;
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
        // Search for an enemy
        float vision = character.getCharacterStats().getVision();
        Vector2 topLeft = (Vector2)character.transform.position - new Vector2(vision, -vision);
        Vector2 botRight = (Vector2)character.transform.position + new Vector2(vision, -vision);

        List<EnemyCharacter> eQuery = LevelManager.instance().current().getObjectsInRange<EnemyCharacter>(topLeft, botRight);

        if (eQuery != null)
        {
            EnemyCharacter target = null;
            float closest = vision;

            foreach (EnemyCharacter e in eQuery)
            {
                float distance = (e.transform.position - character.transform.position).magnitude;
                if (distance <= closest)
                {
                    target = e;
                    closest = distance;
                }
            }

            if (target != null)
            {
                return new AttackingAI(target);
            }
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
