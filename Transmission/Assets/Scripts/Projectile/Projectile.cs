﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour {

    private BaseCharacter origin;
    private float distanceLimit;
    private float distanceTraveled;
    private Rigidbody2D rigidBody;
    private Vector2 lastPosition;
    private List<ProjectileBehaviour> behaviours;
    private int projectileDamage;
    private bool friendly;

	// Use this for initialization
	void Start () {
        behaviours = new List<ProjectileBehaviour>();
        lastPosition = transform.position;
    }

    public void init(BaseCharacter p, Vector2 velocity, float range, int damage)
    {
        rigidBody = GetComponent<Rigidbody2D>();

        origin = p;
        rigidBody.velocity = velocity;
        distanceLimit = range;
        distanceTraveled = 0.0f;
        projectileDamage = damage;
        friendly = p.isFriendlyUnit();
    }

    public void addBehaviour(ProjectileBehaviour b)
    {
        b.setProjectile(this);
        behaviours.Add(b);
    }

    public void setVelocity(Vector2 v)
    {
        rigidBody.velocity = v;
        rigidBody.rotation = convertToAngle(v);
    }

    public void setAngle(Vector2 a)
    {
        rigidBody.rotation = convertToAngle(a);
    }

    static public float convertToAngle(Vector2 v)
    {
        return ((v.x < 0) ? -1 : 1) * Vector2.Angle(Vector2.down, v); 
    }

	// Update is called once per frame
	void Update () {
		
	}

    private void FixedUpdate()
    {
        distanceTraveled += ((Vector2)transform.position - lastPosition).sqrMagnitude;
        if(distanceTraveled >= distanceLimit)
        {
            Destroy(gameObject);
        }

        foreach(ProjectileBehaviour b in behaviours)
        {
            b.logicTick();
        }
    }

    public Vector2 getVelocity()
    {
        return rigidBody.velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Triggered");
        foreach(ProjectileBehaviour b in behaviours)
        {
            b.onCollide(collision);
        }
        
        BaseCharacter c = collision.gameObject.GetComponent<BaseCharacter>();
        if (c != null)
        {
            Debug.Log("Bullet is " + friendly);
            Debug.Log("Enemy is " + c.isFriendlyUnit());
        }
        if (c != null && c.isFriendlyUnit() != friendly)
        {
            Debug.Log("I got here");
            c.applyDamage(projectileDamage);
            Destroy(gameObject);
        }
    }
}
