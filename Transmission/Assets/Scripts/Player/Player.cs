using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {


	SpriteRenderer cursor;

	public Ability[] abilities;
	public float cameraPanSpeed;

	public GameObject RangeCircle;
	private GameObject range;

	public int selected = 0;

	private Vector2 middle;
		
	private const int screenWidth = 1280;
	private const int screenHeight = 720;

	private const float xScreenRatio = (640f / 72f);
	private const float yScreenRatio = (360f / 72f);


	[HideInInspector]
	public BaseCharacter inspecting = null;

	// singleton stuff
	private static Player inst = null;
	public static Player instance(){
		return inst;
	}

	void Start () {
		
		// singleton stuff
		if (!inst) {
			inst = this;
		} else if (inst != this) {
			Destroy (gameObject);
		}

		// set cursor invisible
		Cursor.visible = false;
		middle = new Vector2((float)(screenWidth/2),(float) (screenHeight / 2));
		Camera.main.transform.SetParent(this.transform);
		
		cursor = new GameObject("Cursor").AddComponent<SpriteRenderer>();
		cursor.transform.position = Vector3.zero;
		cursor.sortingLayerName = "UI";
		Color c = cursor.color;
		c.a = 140f / 256f;
		cursor.color = c;


		range = Instantiate(RangeCircle);
		range.transform.SetParent(cursor.transform);
        abilities = GetComponentsInChildren<Ability>();
	}

	void switchToAbility(int index, Vector2 worldCursorPos){

		if(index == selected) return;

		if(selected==0 && index!=0) {
			Destroy(range);
		}

		if(selected == 1) {
			inspecting = null;
		}

		selected = index;
		abilities[selected].updateValidity(worldCursorPos);
		abilities[selected].updateCursorSprite(cursor);

		if(selected == 0) {
			range = Instantiate(RangeCircle);
			range.transform.SetParent(cursor.transform, false);
		}

	}

	void move(Vector2 dir){
		dir *= cameraPanSpeed;
		this.transform.Translate(dir);
	}

	public bool isValidMousePos(Vector2 mouseVec){
		return !(mouseVec.x < -1.0f || mouseVec.x > 1.0f || mouseVec.y < -1.0f || mouseVec.y > 1.0f);
	}

	public Vector2 screenToWorld(Vector2 mouseVec){
		return new Vector2(mouseVec.x * xScreenRatio + transform.position.x, 
			mouseVec.y * yScreenRatio + transform.position.y);
	}

	public Vector2 getNormalizedMouseCoords(){
		return new Vector2(
           2*(Input.mousePosition.x - middle.x) / (float)screenWidth,
		   2*(Input.mousePosition.y - middle.y) / (float)screenHeight);
	}


	// Update is called once per frame
	void Update () {
	

		//Debug.Log(Input.mousePosition);
		// calculate mouse Position as [x,y] => [[-1,1], [-1,1]]
		Vector2 mouseVec = getNormalizedMouseCoords(); 
		// if our mouse pos is valid...
		if(isValidMousePos(mouseVec)) {
			Vector2 mouseWorldPos = screenToWorld(mouseVec);
			cursor.transform.position = mouseWorldPos;

			abilities[selected].updateValidity(mouseWorldPos);
			abilities[selected].updateCursorSprite(cursor);

			if(Mathf.Abs(mouseVec.x) > 0.7f || Mathf.Abs(mouseVec.y) > 0.7f) {
				move(mouseVec);
				inspecting = null;
			}

			if(inspecting) {
				transform.position = inspecting.transform.position;
			}


			if (Input.GetMouseButtonUp(0)){
				abilities[selected].use(mouseWorldPos);
			}

			if (Input.GetKeyDown(KeyCode.Alpha1)){
				switchToAbility(0,mouseWorldPos);
			}

			if(Input.GetKeyDown(KeyCode.Alpha2)) {
				switchToAbility(1, mouseWorldPos);
			}

			if(Input.GetKeyDown(KeyCode.Alpha3)) {
				switchToAbility(2, mouseWorldPos);
			}

		}


	}
}
