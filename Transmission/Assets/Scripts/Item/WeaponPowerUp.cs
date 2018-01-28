using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPowerUp : FriendlyItem {

    public ProjectileSpawnerBehaviour powerUp;

    public override void applyToCharacter(BaseCharacter b)
    {
        if(b.isFriendlyUnit())
        {
            b.addSpawnerBehaviour(Instantiate(powerUp));
            Destroy(gameObject);
        }
    }
}
