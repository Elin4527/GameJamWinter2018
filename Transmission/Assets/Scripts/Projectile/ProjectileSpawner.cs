﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BaseCharacter))]
public class ProjectileSpawner : MonoBehaviour {

    public float range;
    public float speed;
    public float cooldown;
    public float timeElapsed;
    public float offset;
    public bool firing = false;
    public Projectile projectilePrefab;
    public BaseCharacter parent;
    public ProjectileBehaviour[] behaviours;

	// Use this for initialization
	void Start () {
        parent = GetComponent<BaseCharacter>();
	}
	
    public void setFiring(bool fire)
    {
        firing = fire;
    }

    public bool getFiring()
    {
        return firing;
    }

	// Update is called once per frame
	void Update () {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > cooldown && firing)
        {
            fireProjectile();
            timeElapsed -= cooldown;
        }
	}

    void fireProjectile()
    {
        float angle = Projectile.convertToAngle(parent.getDirection());
        Projectile p = Instantiate(projectilePrefab, transform.position + (Vector3)parent.getDirection() * offset, Quaternion.Euler(0, 0, angle));
        p.init(parent, parent.getDirection() * speed, range);
        foreach(ProjectileBehaviour b in behaviours)
        {
            p.addBehaviour(Instantiate(b, transform));
        }
    }
}
