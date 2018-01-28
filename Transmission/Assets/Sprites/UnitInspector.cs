using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UnitInspector : MonoBehaviour {

    private Text[] labels;

	// Use this for initialization
	void Start () {
        labels = GetComponentsInChildren<Text>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Player.instance().inspecting != null)
        {
            BaseCharacter c = Player.instance().inspecting;
            labels[0].text = c.isFriendlyUnit() ? "Ally" : "Enemy";
            labels[1].text = "Health: " + c.getCharacterStats().getHealth() + " / " + c.getCharacterStats().getMaxHealth();
            labels[2].text = "Power: " + c.getCharacterStats().getPower();
            labels[3].text = "Defense: " + c.getCharacterStats().getDefense();
            labels[4].text = "Move Speed: " + c.getCharacterStats().getSpeed();
            labels[5].text = "Attack Speed: " + (1.0f / c.GetComponent<ProjectileSpawner>().getCooldown());
            labels[6].text = "Attack Range: " + c.GetComponent<ProjectileSpawner>().getAttackRange();
            labels[7].text = "Vision Range: " + c.getCharacterStats().getVision();
        }
	}
}
