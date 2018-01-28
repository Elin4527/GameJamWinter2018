using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyCharacter : BaseCharacter {
    protected override void init()
    {
        startingAI = new AllyDefaultAI();
        friendly = true;
    }

}
