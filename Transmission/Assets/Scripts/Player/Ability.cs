using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ability : MonoBehaviour {

	public int count;
	public float cooldown;
	public float delay;

	private float remainingTime;
	private bool isAvailable = true;
	protected bool validity;

    public Sprite icon;
		

	void Start () {}

	public bool isValid(){
		return validity;
	}

	public float getRemainingTime(){
		if(isAvailable) {
			return -1.0f;
		}
		return remainingTime;
	}

	public void use(Vector2 mouseWorldPos){

        Debug.Log("Is Available " + isAvailable);
        Debug.Log("Time Remaining " + remainingTime);
		if(isAvailable && isValid()) {
			activateAbility(delay, mouseWorldPos);
			if(cooldown > 0) {
				isAvailable = false;
				remainingTime = cooldown;
			}
		}
	}

	protected abstract void activateAbility(float delay, Vector2 mouseWorldPos);

	public abstract void updateValidity(Vector2 mouseWorldPos);

	public abstract void updateCursorSprite(SpriteRenderer cursor);

	// Update is called once per frame
	protected void Update () {

		if(!isAvailable) {
			remainingTime -= Time.deltaTime;
            Debug.Log("Decreasing Time" + remainingTime);
			if(remainingTime <= 0.0f) {
				isAvailable = true;
			}
		}
	}

}
