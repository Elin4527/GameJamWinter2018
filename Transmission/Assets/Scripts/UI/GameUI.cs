using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour {

    private UnitInspector inspector;
    private AbilityBar abilityBar;

	// Use this for initialization
	void Start () {
        inspector = GetComponentInChildren<UnitInspector>();
        inspector.gameObject.SetActive(false);
        abilityBar = GetComponentInChildren<AbilityBar>();
	}
	
	// Update is called once per frame
	void Update () {
        inspector.gameObject.SetActive(Player.instance().inspecting != null);
        if (!abilityBar.isInitialized())
        {
            abilityBar.init();
        }
	}
}
