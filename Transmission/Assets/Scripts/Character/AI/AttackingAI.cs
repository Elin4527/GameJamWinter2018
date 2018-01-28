using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingAI : AIBase {

    public BaseCharacter target;
    public AttackingAI(BaseCharacter t)
    {
        target = t;
    }

    public override Vector2 frameInput()
    {
        if (target != null && ((target.transform.position - character.transform.position).magnitude > character.GetComponent<ProjectileSpawner>().getAttackRange() 
            || isPathBlocked(target.transform.position)))
        {
            return pathTo(target.transform.position);
        }
        return Vector2.zero;
    }

    public override AIBase fixedLogicTick()
    {
        ProjectileSpawner weapon = character.GetComponent<ProjectileSpawner>();
        if (target != null && (target.transform.position - character.transform.position).magnitude < character.GetComponent<ProjectileSpawner>().getAttackRange())
        {
            weapon.setFiring(true);
            character.setDirection(target.transform.position - character.transform.position);
        }
        else {
            weapon.setFiring(false);
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
