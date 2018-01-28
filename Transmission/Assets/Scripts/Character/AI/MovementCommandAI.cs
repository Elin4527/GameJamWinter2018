using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCommandAI : AIBase {

    private float threshold;
    private Vector2 dest;

    public MovementCommandAI(Vector2 origin, float radius)
    {
        dest = origin;
        threshold = radius;
    }

    public override Vector2 frameInput()
    {
        if ((dest - (Vector2)character.transform.position).magnitude > threshold)
        {
            return pathTo(dest);
        }
        return Vector2.zero;
    }

    public override AIBase fixedLogicTick()
    {
        character.GetComponent<ProjectileSpawner>().setFiring(false);
        return null;
    }

    public override bool isValid()
    {
        return ((dest - (Vector2)character.transform.position).magnitude > threshold);
    }

    public override void logicTick()
    {
        return;
    }
}
