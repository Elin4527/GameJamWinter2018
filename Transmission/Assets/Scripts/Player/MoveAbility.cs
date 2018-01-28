using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveAbility : AreaAbility {

	public RingLoader r;
	bool activated = false;
	float delayCountdown;
	Vector2 pos;

	// Use this for initialization
	void Start () {}

	protected override void activateAbility(float delay, Vector2 mouseWorldPos){
		Instantiate(r).init(radius, delay, mouseWorldPos);

		activated = true;
		delayCountdown = delay;
		pos = mouseWorldPos;
	}
		

	protected override void updateSpecificValidity(Vector2 mouseWorldPos){
		// if cursor is too far from characters set validity to false;
	}

	// Update is called once per frame
	void Update () {
		base.Update();

		if(activated) {
			delayCountdown -= Time.deltaTime;
			if(delayCountdown < 0) {
				Debug.Log("MoveAbility Activated!");
				activated = false;
			}
		}
	}
}
