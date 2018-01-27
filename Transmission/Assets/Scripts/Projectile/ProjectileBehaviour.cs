using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour {

    protected Projectile projectile;

	// Use this for initialization
	void Start () {
        projectile = GetComponent<Projectile>();
        startUp();
	}

    protected virtual void startUp()
    { }

    public virtual void logicTick()
    { }

    public virtual void onCollide(Collision2D collider)
    { }
}
