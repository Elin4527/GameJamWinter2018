using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour {

    protected Projectile projectile;

    public void setProjectile(Projectile p)
    {
        projectile = p;
    }

    public virtual void startUp()
    { }

    public virtual void logicTick()
    { }

    public virtual void onCollide(Collider2D collider)
    { }
}
