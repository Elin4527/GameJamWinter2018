using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas))]
public class HealthBar : MonoBehaviour {
    private Image background;
    private Image foreground;
    private BaseCharacter character;

    // Use this for initialization
    void Start() {
        background = GetComponentsInChildren<Image>()[0] as Image;
        foreground = GetComponentsInChildren<Image>()[1] as Image;
        character = GetComponentInParent<BaseCharacter>();
    }

    // Update is called once per frame
    void Update()
    {
        background.rectTransform.rotation = Quaternion.identity;
        background.rectTransform.localPosition = Quaternion.Inverse(character.transform.rotation) * new Vector3(0.0f, 0.75f, 0.0f);

        foreground.rectTransform.rotation = Quaternion.identity;
        foreground.rectTransform.localPosition = Quaternion.Inverse(character.transform.rotation) * new Vector3(0.0f, 0.75f, 0.0f);


        float percent = character.getCharacterStats().getHealth() / (float)character.getCharacterStats().getMaxHealth();
        foreground.fillAmount = percent;
        if(percent > 0.5f)
        {
            foreground.color = Color.green;
        }
        else if(percent > 0.25f)
        {
            foreground.color = new Color(1.0f, 0.75f, 0.0f);
        }
        else
        {
            foreground.color = Color.red;
        }
    }
}
