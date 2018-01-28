using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SpawnEnemyEvent : TimelineEvent{

	public Vector2Int tileCoords;
	public EnemyCharacter enemy;

	public SpawnEnemyEvent(float time, Vector2Int tileCoords, EnemyCharacter enemy, bool delta = false)
        : base(time, delta)
    {
		this.tileCoords = tileCoords;
		this.enemy = enemy;
	}


	public override void execute(){
        EnemyCharacter e = UnityEngine.Object.Instantiate(enemy, Vector3.zero, new Quaternion());
        LevelManager.instance().current().addLevelEntity(e, tileCoords);
	}

}
