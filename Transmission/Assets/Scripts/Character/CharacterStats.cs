﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats {

    private int maxHealth;
    private int currHealth;

    private int defense;

    private int power;
    private float speed;

    private float vision;

    public void modifyVision(float change)
    {
        vision += change;
        if (vision < 0) vision = 0;
    }

    public void modifyDefense(int change)
    {
        defense += change;
    }

    public void setDefense(int value)
    {
        defense = value;
    }

    public int getDefense()
    {
        return defense;
    }

    public void modifyMaxHealth(int change)
    {
        maxHealth += change;
        if (maxHealth < 0)
        {
            maxHealth = 0;
        }

        modifyHealth(0);
    }

    public void modifyHealth(int change)
    {
        currHealth += change;

        if (currHealth < 0)
        {
            currHealth = 0;
        }
        if (currHealth > maxHealth)
        {
            currHealth = maxHealth;
        }
    }

    public void modifySpeed(float change)
    {
        speed += change;
        if (speed < 0) speed = 0;
    }

    public void modifyPower(int change)
    {
        power += change;
        if (power < 0) power = 0;
    }

    public void setVision(float value)
    {
        modifyVision(value - vision);
    }

    public void setMaxHealth(int value)
    {
        modifyMaxHealth(value - maxHealth);
    }

    public void setHealth(int value)
    {
        modifyHealth(value - currHealth);
    }

    public void setSpeed(float value)
    {
        modifySpeed(value - speed);
    }

    public void setPower(int value)
    {
        modifyPower(value - power);
    }

    public float getVision()
    {
        return vision;
    }

    public int getHealth()
    {
        return currHealth;
    }

    public int getMaxHealth()
    {
        return maxHealth;
    }

    public float getSpeed()
    {
        return speed;
    }

    public int getPower()
    {
        return power;
    }
}
