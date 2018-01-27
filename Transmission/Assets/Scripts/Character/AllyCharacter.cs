using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCharacter : BaseCharacter {
    protected override void init()
    {
        startingAI = new AllyDefaultAI();
        friendly = true;
    }
    public override void fixedLogic()
    {
        base.fixedLogic();
    }

}
