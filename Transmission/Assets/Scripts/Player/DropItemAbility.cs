using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropItemAbility : AreaAbility {

    public Item i;
	public RingLoader r;

	// Use this for initialization
	void Start () {}

	protected override void activateAbility(float delay, Vector2 mouseWorldPos){
		Instantiate(r).init(radius, delay, mouseWorldPos,c);
		Debug.Log("Ability 3 activated");
		
		LevelManager.instance().currentTimeline().addEventToQueue(
			new ItemSpawnEvent(delay, 
				LevelManager.instance().current().tileMapRef.getTileCoords(mouseWorldPos), i,
				true));
		
	}

	protected override void updateSpecificValidity(Vector2 mouseWorldPos){}
}