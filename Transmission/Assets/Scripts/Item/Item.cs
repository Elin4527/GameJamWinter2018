using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public abstract class Item : MapObject {

    protected bool friendly;

    public bool isFriendly()
    {
        return friendly;
    }
    public abstract void applyToCharacter(BaseCharacter b);

    public void OnTriggerEnter2D(Collider2D collision)
    {
        BaseCharacter b = collision.GetComponent<BaseCharacter>();
        if (b)
        {
            applyToCharacter(b);
        }
    }
}
