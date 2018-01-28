using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SelectionAbility : Ability {

	public Sprite cursorDefault;
	public Sprite cursorAllowed;
	public Color c;

	protected BaseCharacter mouseOver;

	void Start() {}

	public override void updateValidity(Vector2 mouseWorldPos){

		//mouseWorldPos = Player.instance().screenToWorld(Player.instance().getNormalizedMouseCoords());
		List<BaseCharacter> nearby = LevelManager.instance().current()
			.getObjectsInRange<BaseCharacter>(
                 mouseWorldPos + new Vector2(-0.1f, 0.1f),
                 mouseWorldPos + new Vector2(0.1f, -0.1f)); 

		if (nearby == null){
			mouseOver = null;
			base.validity = false;
			return;
		}
		nearby.Sort((char1, char2) => {
			return Vector2.Distance(char1.transform.position, mouseWorldPos)
				.CompareTo(Vector2.Distance(char1.transform.position, mouseWorldPos));
			});

		mouseOver = nearby[0]; 
		base.validity = true;
		updateSpecificValidity(mouseWorldPos);

	}
	protected abstract void updateSpecificValidity(Vector2 mouseWorldPos);



	public override void updateCursorSprite(SpriteRenderer cursor){

		cursor.transform.localScale = Vector3.one;

		Color toSet;
		float alpha = cursor.color.a;
		if(isValid()) {
			cursor.sprite = cursorAllowed;
			toSet = Color.white;
		} else {
			cursor.sprite = cursorDefault;
			toSet = c;
		}
		toSet.a = alpha;
		cursor.color = toSet;
	}
}
