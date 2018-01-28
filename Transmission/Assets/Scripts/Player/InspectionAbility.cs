using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InspectionAbility : SelectionAbility {

	// Use this for initialization
	void Start (){}

	protected override void activateAbility(float delay, Vector2 mouseWorldPos)
	{
		Player.instance().inspecting = mouseOver;
	}

	protected override void updateSpecificValidity(Vector2 mouseWorldPos){}

}
