using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCharacter : BaseCharacter {

    protected override void init()
    {
        startingAI = new EnemyDefaultAI();
        friendly = false;
    }
}
