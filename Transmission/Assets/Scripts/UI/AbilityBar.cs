using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityBar : MonoBehaviour {

    private List<Image> icons;
    private bool initialized = false;

	// Use this for initialization
	void Start () {

	}

    public void init()
    {
        if (!initialized)
        {
            Ability[] abilities = Player.instance().abilities;

            float spacing = 1000.0f / abilities.Length;
            icons = new List<Image>();
            for (int i = 0; i < abilities.Length; i++)
            {
                Image im = new GameObject().AddComponent<Image>();
                im.rectTransform.SetParent(transform, false);
                im.rectTransform.localPosition = new Vector3(((i - abilities.Length / 2.0f) + 0.5f) * spacing, 5.0f, 0.0f);
                im.sprite = abilities[i].icon;
                icons.Add(im);
            }
            initialized = true;
        }
    }

    public bool isInitialized()
    {
        return initialized;
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < icons.Count; i++)
        {
            float channel = (Player.instance().abilities[i].getRemainingTime() > 0) ? 0.5f : 1.0f;

            if (i == Player.instance().selected)
            {
                icons[i].color = new Color(channel, channel, channel, 1.0f);
            }
            else {
                icons[i].color = new Color(channel, channel, channel, 0.5f);
            }
        }
	}
}
