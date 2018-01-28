using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingProjectile : ProjectileBehaviour {

    bool used = false;
    public override void onCollide(Collider2D collider)
    {
        if(!used && !projectile.hasShield())
        {
            projectile.giveShield();
            used = true;
        }
    }
}
