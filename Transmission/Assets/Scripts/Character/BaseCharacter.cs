using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class BaseCharacter : MonoBehaviour {

    public int startingHealth;
    public float startingSpeed;
    public int startingPower;
    public int startingDefense;
    public AIBase startingAI;

    private Vector2 currentVelocity;
    private Vector2 velocityDelta;
    private Vector2 targetVelocity;
    private Vector2 direction;

    private TileMap gameLevel;

    private Stack<AIBase> ai;

    protected bool friendly;

    protected CharacterStats characterStats;

	// Use this for initialization
	void Start () {
        characterStats = new CharacterStats();
        ai = new Stack<AIBase>();
        init();
        initStats(startingHealth, startingSpeed, startingPower, startingDefense);
        if(startingAI != null)
        {
            addAIState(startingAI);
        }
	}

    public void setTileMap(TileMap map)
    {
        gameLevel = map;
    }

    public TileMap getTileMap()
    {
        return gameLevel;
    }

    public bool isFriendlyUnit()
    {
        return friendly;
    }

    public void addAIState(AIBase state)
    {
        state.setCharacter(this);
        ai.Push(state);
    }

    public void swapAIState(AIBase state)
    {
        ai.Pop();

        state.setCharacter(this);
        ai.Push(state);
    }

    protected void initStats(int health, float speed, int power, int defense)
    {
        characterStats.setMaxHealth(health);
        characterStats.setHealth(health);
        characterStats.setSpeed(speed);
        characterStats.setPower(power);
        characterStats.setDefense(defense);
    }

    public void applyDamage(int damage)
    {
        characterStats.modifyHealth(-damage);
        Debug.Log("Health is " + characterStats.getHealth());
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
        transform.rotation = Quaternion.Euler(0, 0, convertToAngle(d));
    }

    public Vector2 getDirection()
    {
        return convertFromAngle(transform.rotation.eulerAngles.z);
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
    static public Vector2 convertFromAngle(float angle)
    {
        float x = Mathf.Sin(Mathf.Deg2Rad * angle);
        float y = -Mathf.Cos(Mathf.Deg2Rad * angle);
        return new Vector2(x, y);
    }

    public virtual Vector2 getMovementInput()
    {
        if (ai.Count > 0)
        {
            return ai.Peek().frameInput();
        }
        return Vector2.zero;
    }
    public virtual void logic()
    {
        if(ai.Count > 0)
        {
            ai.Peek().fixedLogicTick();
        }
    }
    public virtual void fixedLogic()
    {
        while (ai.Count > 0 && !ai.Peek().isValid())
        {
            ai.Pop();
        }
        if (ai.Count > 0)
        {
            ai.Peek().fixedLogicTick();
        }

        if (characterStats.getHealth() <= 0)
        {
            Destroy(gameObject);
        }
    }
}
