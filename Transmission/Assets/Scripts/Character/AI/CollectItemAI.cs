using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectItemAI : AIBase {

    Item target;

    public CollectItemAI(Item item)
    {
        target = item;
    }

    public override Vector2 frameInput()
    {
        if (target != null)
        {
            return pathTo(target.transform.position);
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

        return null;
    }

    public override bool isValid()
    {
        return (target != null && (target.transform.position - character.transform.position).magnitude <= character.getCharacterStats().getVision());
    }

    public override void logicTick()
    {
        return;
    }
}
