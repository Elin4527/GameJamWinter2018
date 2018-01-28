using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AreaAbility : Ability {

	public float radius;
	public Sprite allowed;
	public Sprite notAllowed;
	public Color c;

	// Use this for initialization
	void Start () {}

	public override void updateValidity(Vector2 mouseWorldPos){
		if(Physics2D.OverlapCircle(mouseWorldPos, radius, LayerMask.GetMask("Wall"))) {
			base.validity = false;
		} 
		else {
			base.validity = true;
			updateSpecificValidity(mouseWorldPos);
		}
	}

	public override void updateCursorSprite(SpriteRenderer cursor){
		float ratio = radius / 0.5f;
		if(cursor.transform.localScale.x != ratio) {
			cursor.transform.localScale = new Vector3(ratio,ratio,ratio);
		}
		Color toSet;
		float alpha = cursor.color.a;
		if(isValid()) {
			cursor.sprite = allowed;
			toSet = c;
		} else {
			cursor.sprite = notAllowed;
			toSet = Color.white;
		}
		toSet.a = alpha;
		cursor.color = toSet;
	}

	protected abstract void updateSpecificValidity(Vector2 mouseWorldPos);

}
