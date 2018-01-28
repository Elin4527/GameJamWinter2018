using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : Item {

    public int damage;
    public int times = 0;
    public float cooldown;
    private float timeElapsed;

    public Hazard()
    {
        friendly = false;
    }

    public void Update()
    {
        timeElapsed += Time.deltaTime;
    }

    public override void applyToCharacter(BaseCharacter b)
    {
        if (!b.isFriendlyUnit() && timeElapsed >= cooldown)
        {
            b.applyDamage(damage);
            times--;
            if (times == 0)
            {
                Destroy(gameObject);
            }
            timeElapsed = 0;
        }
    }
}
