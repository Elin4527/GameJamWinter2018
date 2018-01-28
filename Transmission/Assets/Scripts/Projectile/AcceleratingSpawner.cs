using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratingSpawner : ProjectileSpawnerBehaviour
{
    public override void applyProjectileModifications(Projectile p)
    {
        p.addBehaviour(new AcceleratingProjectile());
    }

    public override void applySpawnerModifications(ProjectileSpawner p)
    {
    }

    public override void onFireAttempted(ProjectileSpawner p)
    {
    }
}
