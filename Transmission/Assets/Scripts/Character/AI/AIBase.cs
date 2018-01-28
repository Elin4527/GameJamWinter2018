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
    public abstract AIBase fixedLogicTick();
    public abstract Vector2 frameInput();
    public abstract bool isValid();

    protected bool isPathBlocked(Vector2 dest)
    {
        float width = character.GetComponent<CircleCollider2D>().radius;

        Vector2 left = (Quaternion.Euler(0, 0, 90) * character.getDirection()) * width + character.transform.position;
        Vector2 right = (Quaternion.Euler(0, 0, -90) * character.getDirection()) * width + character.transform.position;

        Vector2 target = dest - (Vector2)character.transform.position;
        RaycastHit2D collision = Physics2D.Raycast(character.transform.position, target.normalized, target.magnitude, LayerMask.GetMask("Wall"));

        RaycastHit2D collideLeft = Physics2D.Raycast(left, target.normalized, target.magnitude, LayerMask.GetMask("Wall"));
        RaycastHit2D collideRight = Physics2D.Raycast(right, target.normalized, target.magnitude, LayerMask.GetMask("Wall"));

        return ((collision.collider != null) || (collideLeft.collider != null) || (collideRight.collider != null));
    }

    protected Vector2 pathTo(Vector2 target)
    {
        Vector2 direction = Vector2.zero;
        if (!isPathBlocked(target))
        {
            direction = (target - (Vector2)character.transform.position).normalized;
        }
        else
        {
            List<Vector2> dest = pathFinder.pathFindTo(character.transform.position, target, character.getTileMap());
            if(dest != null && dest.Count > 0)
            {
                int i;
                for (i = dest.Count - 1; i > 1; i--)
                {
                    if (!isPathBlocked(dest[i])) break;
                }
                direction = (dest[i] - (Vector2)character.transform.position).normalized;
            }

        }
        if (direction != Vector2.zero) character.setDirection(direction);
        return direction * character.getCharacterStats().getSpeed();
    }

}
