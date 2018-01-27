using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour {

    protected Projectile projectile;

	// Use this for initialization
	void Start () {
        startUp();
	}

    public void setProjectile(Projectile p)
    {
        projectile = p;
    }

    protected virtual void startUp()
    { }

    public virtual void logicTick()
    { }

    public virtual void onCollide(Collider2D collider)
    { }
}
