using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiercingSpawner : ProjectileSpawnerBehaviour {
    public override void applyProjectileModifications(Projectile p)
    {
        p.addBehaviour(new PiercingProjectile());
    }

    public override void applySpawnerModifications(ProjectileSpawner p)
    {
    }

    public override void onFireAttempted(ProjectileSpawner p)
    {
                                                                                                                           }

}
