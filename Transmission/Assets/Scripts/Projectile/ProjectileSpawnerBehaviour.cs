using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ProjectileSpawnerBehaviour {

    void applySpawnerModifications(ProjectileSpawner p);
    void applyProjectileModifications(Projectile p);
}
