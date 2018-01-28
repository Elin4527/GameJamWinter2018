using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextEffect : MonoBehaviour {

    private float duration;
    private float totalDuration;
    bool shouldFade;
    private Text textRef;

    public void createText(string text, int fontSize, Font font, Color color, float duration, bool fade)
    {
        Debug.Log("This function is called");
        textRef = gameObject.AddComponent<Text>();
        textRef.text = text;
        textRef.fontSize = fontSize;
        textRef.font = font;
        textRef.color = color;
        textRef.alignment = TextAnchor.MiddleCenter;

        this.duration = duration;
        totalDuration = duration;
        shouldFade = fade;

        Debug.Log("The Text should be made");
    }

    // Update is called once per frame
    void Update () {
        duration -= Time.deltaTime;

        
        if (shouldFade)
        {
            textRef.color = new Color(textRef.color.r, textRef.color.g, textRef.color.b, (duration > 0.0f)? (duration / totalDuration) : 0);
        }
	}

    public bool isExpired()
    {
        return duration <= 0.0f;
    }
}
