using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileSpawnerBehaviour: MonoBehaviour{

    public abstract void applySpawnerModifications(ProjectileSpawner p);
    public abstract void onFireAttempted(ProjectileSpawner p);
    public abstract void applyProjectileModifications(Projectile p);
}
