using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RingLoader : MonoBehaviour {


	private float timeRemaining;
	private float time;
	private Image image;
	public void init(float radius, float time, Vector2 pos, Color c){
		float ratio = radius / 0.5f;
		transform.localScale = new Vector3(ratio,ratio,ratio);

		this.time = time;
		timeRemaining = this.time;
		image = GetComponentsInChildren<Image>()[0] as Image;
		Color temp = image.color;
		temp.r = c.r; 
		temp.g = c.g;
		temp.b = c.b;
		image.color = temp;
		((Image)GetComponentsInChildren<Image>()[1]).color = temp;
		transform.position = pos;
	}
	// Use this for initialization
	void Start () {}
	
	// Update is called once per frame
	void Update () {
		timeRemaining -= Time.deltaTime;
		image.fillAmount = (timeRemaining / time);
		if(timeRemaining < 0) {
			Destroy(this.gameObject);
		}
	}
}
