using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcceleratingProjectile : ProjectileBehaviour {

    Vector2 initVelocity;

    public override void startUp()
    {
        initVelocity = projectile.getVelocity();
    }

    public override void logicTick()
    {
        Vector2 currVel = projectile.getVelocity();
        projectile.setVelocity(currVel + (currVel.normalized * 0.1f * Time.fixedDeltaTime));
    }

    public override void onCollide(Collider2D collider)
    {
        collider.GetComponent<BaseCharacter>().applyDamage((int)((projectile.getVelocity() - initVelocity).magnitude));
    }
}
