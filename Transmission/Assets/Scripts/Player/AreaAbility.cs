using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AreaAbility : Ability {

	public float radius;
	public Sprite allowed;
	public Sprite notAllowed;

	// Use this for initialization
	void Start () {}

	public override void updateValidity(Vector2 mouseWorldPos){
		if(Physics2D.OverlapCircle(mouseWorldPos, radius, LayerMask.NameToLayer("Wall"))) {
			base.validity = false;
		} else {
			base.validity = true;
			updateSpecificValidity(mouseWorldPos);
		}
	}

	public override void updateCursorSprite(SpriteRenderer cursor){
		float ratio = radius / 0.5f;
		if(cursor.transform.localScale.x != ratio) {
			cursor.transform.localScale = new Vector3(ratio,ratio,ratio);
		}
		if(isValid()) {
			cursor.sprite = allowed;
		} else {
			cursor.sprite = notAllowed;
		}
	}

	protected abstract void updateSpecificValidity(Vector2 mouseWorldPos);

}
