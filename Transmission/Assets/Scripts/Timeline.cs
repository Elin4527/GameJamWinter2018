using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timeline : MonoBehaviour {

	public SpawnEnemyEvent [] spawnEnemyEvents;
	public float nextLevelDelay;
	//private NextLevelEvent nextLevelEvent;

	private List<TimelineEvent> queuedEvents = new List<TimelineEvent>();

	private bool imminentExit;
	private float clock = 0f;

	// Use this for initialization
	void Start () {
		foreach(SpawnEnemyEvent e in spawnEnemyEvents) {
			addEventToQueue(e);
		}
		//queuedEvents.Sort((a, b) => a.getStartTime().CompareTo(b.getStartTime()));
	}

	public void addEventToQueue(TimelineEvent e){
		for (int i = 0; i< queuedEvents.Count; i++){
			if(queuedEvents[i].getStartTime() > e.getStartTime()) {
				queuedEvents.Insert(i, e);
				return;
			}
		}
		queuedEvents.Add(e);
	}

	// Update is called once per frame
	void Update () {
		this.clock += Time.deltaTime; 

		while(queuedEvents.Count!=0 && clock > queuedEvents[0].getStartTime()) {
			queuedEvents[0].execute();
			queuedEvents.RemoveAt(0);
		}
	}

	public float getTime(){
		return clock;
	}
}
