using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnEnemyEvent : TimelineEvent{

	public float despawnTime;
	public Vector2 tileCoords;
	public GameObject enemy;
	public GameObject attack;

	public SpawnEnemyEvent(float time, float despawn, Vector2 tileCoords, GameObject enemy, 
		GameObject attack, bool delta = false) : base(time, delta){
		this.despawnTime = despawn;
		this.tileCoords = tileCoords;
		this.enemy = enemy;
		this.attack = attack;
	}


	public override void execute(){
		enemy.transform.position = LevelManager.instance().convertTileCoords(tileCoords);
		// instantiate enemy and getComponent
		// set despawn time
		// instantiate attack
		// set attack as child of the enemy
	}

}
