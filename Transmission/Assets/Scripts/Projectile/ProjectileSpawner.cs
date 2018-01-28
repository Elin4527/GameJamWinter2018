using System.Collections;
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
    public List<ProjectileSpawnerBehaviour> behaviours;

	// Use this for initialization
	void Start () {
        behaviours = new List<ProjectileSpawnerBehaviour>();
        parent = GetComponent<BaseCharacter>();
	}
	
    public void addSpawnerBehaviour(ProjectileSpawnerBehaviour b)
    {
        b.applySpawnerModifications(this);
        b.transform.parent = transform;
        behaviours.Add(b);
    }

    public void setFiring(bool fire)
    {
        firing = fire;
    }

    public float getAttackRange()
    {
        return range;
    }

    public void modifyAttackRange(float change)
    {
        range += change;
        if (range < 1.0f) range = 1.0f;
    }

    public float getCooldown(float getCooldown)
    {
        return cooldown;
    }

    public void modifyCooldownPercent(float change)
    {
        cooldown *= change;
    }

    public float getSpeed()
    {
        return speed;
    }

    public void modifySpeed(float change)
    {
        speed += change;
        if (speed < 1.0f)
            speed = 1.0f;
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
            startFire();
            timeElapsed = 0.0f;
        }
	}

    private void startFire()
    {
        foreach (ProjectileSpawnerBehaviour b in behaviours)
        {
            b.onFireAttempted(this);
        }
        fireProjectile();
    }

    public void fireProjectile()
    {
        float angle = Projectile.convertToAngle(parent.getDirection());
        Projectile p = Instantiate(projectilePrefab, transform.position + (Vector3)parent.getDirection() * offset, Quaternion.Euler(0, 0, angle));
        p.init(parent, parent.getDirection() * speed, range, parent.getCharacterStats().getPower());
        foreach(ProjectileSpawnerBehaviour b in behaviours)
        {
            b.applyProjectileModifications(p);
        }
    }
}
