using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class DropItemAbility : AreaAbility {

	public Item[] items;
	public RingLoader r;

	// Use this for initialization
	void Start () {}

	protected override void activateAbility(float delay, Vector2 mouseWorldPos){
		Instantiate(r).init(radius, delay, mouseWorldPos,c);

		LevelManager.instance().currentTimeline().addEventToQueue(
			new ItemSpawnEvent(delay, 
				LevelManager.instance().current().tileMapRef.getTileCoords(mouseWorldPos),
				items[Random.Range(0, items.Length)],
				true));
	}

	protected override void updateSpecificValidity(Vector2 mouseWorldPos){}
}