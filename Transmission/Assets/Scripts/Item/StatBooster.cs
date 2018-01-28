using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatBooster : FriendlyItem {

    public int maxHealthModifier;
    public float heal;
    public float speedModifier;
    public int defenseModifier;
    public float visionModifier;
    public int powerModifier;

    public override void applyToCharacter(BaseCharacter b)
    {
        if (b.isFriendlyUnit())
        {
            b.getCharacterStats().modifyMaxHealth(maxHealthModifier);
            b.getCharacterStats().modifyHealth(maxHealthModifier);
            b.getCharacterStats().modifyHealth((int)Mathf.Ceil(heal * b.getCharacterStats().getMaxHealth()));
            b.getCharacterStats().modifySpeed(speedModifier);
            b.getCharacterStats().modifyPower(powerModifier);
            b.getCharacterStats().modifyVision(visionModifier);
            b.getCharacterStats().modifyDefense(defenseModifier);
            Destroy(gameObject);
        }
    }
}
