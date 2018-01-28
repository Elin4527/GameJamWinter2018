using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public abstract class TimelineEvent {

	public float startTime;

	public TimelineEvent(float time, Boolean delta){
		if (delta){
			startTime = LevelManager.instance().currentTimeline().getTime() + time;
		}
		else {
			startTime = time;
		}
	}

	public void setStartTime(float t){
		startTime = t;
	}

	public float getStartTime(){
		return startTime;
	}

	public abstract void execute();
}
