﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseCharacter : MonoBehaviour {

    public int startingHealth;
    public int startingSpeed;
    public int startingPower;
    public int startingDefense;

    private Vector2 currentVelocity;
    private Vector2 velocityDelta;
    private Vector2 targetVelocity;
    private Vector2 direction;

    protected CharacterStats characterStats;

	// Use this for initialization
	void Start () {
        characterStats = new CharacterStats();
        init();
        initStats(startingHealth, startingSpeed, startingPower, startingDefense);
	}

    protected void initStats(int health, int power, int speed, int defense)
    {
        characterStats.setMaxHealth(health);
        characterStats.setHealth(health);
        characterStats.setPower(power);
        characterStats.setSpeed(speed);
    } 

    protected virtual void init()
    { }
	
	// Update is called once per frame
	void Update () {
        Vector2 input = getMovementInput();
        setTargetVelocity(input);
        logic();
	}

    public bool isMoving()
    {
        return currentVelocity != Vector2.zero;
    }

    public bool isWalking()
    {
        return targetVelocity != Vector2.zero;
    }

    public Vector2 getTargetVelocity()
    {
        return targetVelocity;
    }

    public void setTargetVelocity(Vector2 v)
    {
        if (v == targetVelocity)
            return;
        targetVelocity = v;
        velocityDelta = (v - currentVelocity) * (Time.fixedDeltaTime / 0.1f);
    }

    public void setVelocity(Vector2 v)
    {
        currentVelocity = v;
        setTargetVelocity(v);
        velocityDelta = Vector2.zero;
    }

    public void setDirection(Vector2 d)
    {
        direction = d.normalized;
        transform.rotation = Quaternion.Euler(0, 0, convertToAngle(d));
    }

    public Vector2 getDirection()
    {
        return direction;
    }

    public CharacterStats getCharacterStats()
    {
        return characterStats;
    }

    private void FixedUpdate()
    {
        currentVelocity += velocityDelta;
        if (Mathf.Abs(currentVelocity.x - targetVelocity.x) + Mathf.Abs(currentVelocity.y - targetVelocity.y) < 0.1f)
        {
            setVelocity(targetVelocity);
        }
        fixedLogic();
        transform.position += (Vector3)currentVelocity * Time.fixedDeltaTime;
    }

    static public float convertToAngle(Vector2 v)
    {
        return ((v.x < 0) ? -1 : 1) * Vector2.Angle(Vector2.down, v);
    }

    public abstract Vector2 getMovementInput();
    public virtual void logic()
    { }
    public virtual void fixedLogic()
    { }
}
