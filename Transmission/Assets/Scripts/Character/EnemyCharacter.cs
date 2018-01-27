using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : BaseCharacter {

    protected override void init()
    {
        friendly = false;
    }
    public override void fixedLogic()
    {
        base.fixedLogic();
        setDirection(getTargetVelocity());
    }
    public override Vector2 getMovementInput()
    {
        return new Vector2(-0.25f, 0.25f);
    }
}
