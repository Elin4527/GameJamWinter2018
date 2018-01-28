using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDefaultAI : AIBase {

    public override Vector2 frameInput()
    {
        Vector2Int target = LevelManager.instance().current().getSpawnPoint();

        Vector2 dest = character.getTileMap().convertTileCoords(target);
        return pathTo(dest);
    }

    public override AIBase fixedLogicTick()
    {
        // Search for an enemy
        float vision = character.getCharacterStats().getVision();
        Vector2 topLeft = (Vector2)character.transform.position - new Vector2(vision, -vision);
        Vector2 botRight = (Vector2)character.transform.position + new Vector2(vision, -vision);

        List<AllyCharacter> eQuery = LevelManager.instance().current().getObjectsInRange<AllyCharacter>(topLeft, botRight);

        if (eQuery != null)
        {
            AllyCharacter target = null;
            float closest = vision;
            foreach (AllyCharacter a in eQuery)
            {
                float distance = (a.transform.position - character.transform.position).magnitude;
                if (distance <= closest)
                {
                    target = a;
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
