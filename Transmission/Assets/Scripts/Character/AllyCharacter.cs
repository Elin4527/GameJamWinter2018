using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCharacter : BaseCharacter {

    public override Vector2 getMovementInput()
    {
        return new Vector2(1, 0);
    }
}
