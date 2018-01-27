using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnEnemyEvent : TimelineEvent{

	public Vector2 tileCoords;
	public EnemyCharacter enemy;

	public SpawnEnemyEvent(float time, Vector2 tileCoords, EnemyCharacter enemy, bool delta = false)
        : base(time, delta)
    {
		this.tileCoords = tileCoords;
		this.enemy = enemy;
	}


	public override void execute(){
		Vector3 position = LevelManager.instance().current().tileMap.convertTileCoords(tileCoords);
        EnemyCharacter e = UnityEngine.Object.Instantiate(enemy, position, new Quaternion());
        LevelManager.instance().current().addLevelEntity(e.gameObject);
	}

}
