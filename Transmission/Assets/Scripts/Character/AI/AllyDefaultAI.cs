using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyDefaultAI : AIBase {
    public BaseCharacter target;

    public override Vector2 frameInput()
    {
        if(target != null)
        {
            if (!isPathBlocked(target.transform.position))
            {
                return (target.transform.position - character.transform.position).normalized * character.getCharacterStats().getSpeed();
            }
        }
        return Vector2.zero;
    }

    public override void fixedLogicTick()
    {
        if(target == null)
        {
            target = UnityEngine.Object.FindObjectOfType<EnemyCharacter>();
        }
        character.setDirection(character.getTargetVelocity());
        return;
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
