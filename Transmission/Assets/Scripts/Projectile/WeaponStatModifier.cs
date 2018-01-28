using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStatModifier : ProjectileSpawnerBehaviour
{
    public float rangeModifier;
    public float speedModifier;
    public float cooldownPercent;

    public override void applyProjectileModifications(Projectile p)
    {
    }

    public override void applySpawnerModifications(ProjectileSpawner p)
    {
        p.modifyAttackRange(rangeModifier);
        p.modifySpeed(speedModifier);
        p.modifyCooldownPercent(cooldownPercent);
    }

    public override void onFireAttempted(ProjectileSpawner p)
    {
        throw new NotImplementedException();
    }
}
