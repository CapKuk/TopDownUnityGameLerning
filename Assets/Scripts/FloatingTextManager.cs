using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;
    public GameObject textPrefab;

    private List<FloatingText> floatingTexts = new List<FloatingText>();

    public void Show(string message, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText txt = GetFloatingText();

        txt.txt.text = message;
        txt.txt.fontSize = fontSize;
        txt.txt.color = color;

        txt.go.transform.position = Camera.main.WorldToScreenPoint(position);
        
        txt.motion = motion;
        txt.duration = duration;

        txt.Show();
    }

    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if(txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform.parent);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }

        return txt;
    }

    private void Update()
    {
        foreach(FloatingText ft in floatingTexts)
        {
            ft.UpdateFloatingText();
        }
    }
}
