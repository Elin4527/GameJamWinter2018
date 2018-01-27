using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AIBase {

    protected BaseCharacter character;

    public void setCharacter(BaseCharacter c)
    {
        character = c;
    }

    public abstract void logicTick();
    public abstract void fixedLogicTick();
    public abstract Vector2 frameInput();
    public abstract bool isValid();
}
