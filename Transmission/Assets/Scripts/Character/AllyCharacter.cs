using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCharacter : BaseCharacter {
    public override void fixedLogic()
    {
        setDirection(getTargetVelocity());
    }
    public override Vector2 getMovementInput()
    {
        return new Vector2(0.5f, 0.0f);
    }
}
