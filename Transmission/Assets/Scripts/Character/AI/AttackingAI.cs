using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingAI : AIBase {

    public BaseCharacter target;

    public AttackingAI(BaseCharacter character)
    {
        target = character;
    }

    public override Vector2 frameInput()
    {
        if (target != null && (target.transform.position - character.transform.position).magnitude > character.GetComponent<ProjectileSpawner>().getAttackRange())
        {
            return pathTo(target.transform.position);
        }
        return Vector2.zero;
    }

    public override AIBase fixedLogicTick()
    {
        character.GetComponent<ProjectileSpawner>().setFiring(target != null && (target.transform.position - character.transform.position).magnitude < character.GetComponent<ProjectileSpawner>().getAttackRange());

        return null;
    }

    public override bool isValid()
    {
        return target == null || (target.transform.position - character.transform.position).magnitude > character.getCharacterStats().getVision();
    }

    public override void logicTick()
    {
        return;
    }
}
