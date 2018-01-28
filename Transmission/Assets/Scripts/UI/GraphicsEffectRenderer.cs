using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Canvas))]
public class GraphicsEffectRenderer : MonoBehaviour {

    private Canvas canvas;
    private static GraphicsEffectRenderer inst = null;
    public List<TextEffect> effects;
    public Font[] fonts;

	// Use this for initialization
	void Start () {
        canvas = GetComponent<Canvas>();
        if (!inst)
        {
            inst = this;
        }
        else if (inst != this)
        {
            Destroy(gameObject);
        }

        effects = new List<TextEffect>();
    }
	
    static public GraphicsEffectRenderer instance()
    {
        return inst;
    }

    public void createTextEffect(string text, int fontSize, int font, Color color, float duration, bool fade, Vector2 pos)
    {
        GameObject g = new GameObject("Text");
        g.transform.SetParent(transform, false);


        TextEffect t = g.AddComponent<TextEffect>();
        t.createText(text, fontSize, fonts[font], color, duration, fade);

        g.transform.position = pos;
    }

    // Update is called once per frame
    void Update () {
		foreach(TextEffect e in effects)
        {
            if(e.isExpired())
            {
                effects.Remove(e);
                Destroy(e.gameObject);
            }
        }
	}
}
