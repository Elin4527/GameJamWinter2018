using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBase {

    protected BaseCharacter character;
    protected Pathfinding pathFinder;

    protected AIBase()
    {
        pathFinder = new Pathfinding();
    }

    public void setCharacter(BaseCharacter c)
    {
        character = c;
    }

    public abstract void logicTick();
    public abstract void fixedLogicTick();
    public abstract Vector2 frameInput();
    public abstract bool isValid();

    protected bool isPathBlocked(Vector2 dest)
    {
        Vector2 target = dest - (Vector2)character.transform.position;
        RaycastHit2D collision = Physics2D.Raycast(character.transform.position, target.normalized, target.magnitude, LayerMask.GetMask("Wall"));
        return collision.collider != null;
    }

}
