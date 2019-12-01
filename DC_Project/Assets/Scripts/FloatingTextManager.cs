using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatingTextManager : MonoBehaviour
{
    public GameObject textContainer;    // This will be the parent of the floating text objects
    public GameObject textPrefab;       // This should be how you want the base floating text to look
    private List<FloatingText> floatingTexts = new List<FloatingText>();

    private void Update()
    {
        foreach (FloatingText txt in floatingTexts)
            txt.UpdateFloatingText();
    }

    // This is called from the Game Manager, it will find a floating text object and display it on the screen
    public void Show(string msg, int fontSize, Color color, Vector3 position, Vector3 motion, float duration)
    {
        FloatingText floatingText = GetFloatingText();

        floatingText.txt.text = msg;
        floatingText.txt.fontSize = fontSize;
        floatingText.txt.color = color;

        floatingText.go.transform.position = Camera.main.WorldToScreenPoint(position); // Transfer world space to screen space so we can use it in the UI
        floatingText.motion = motion;
        floatingText.duration = duration;

        floatingText.Show();
    }

    // Pooling function, this will get any existing and inactive floating text, if it doesn't find any, it will create one
    private FloatingText GetFloatingText()
    {
        FloatingText txt = floatingTexts.Find(t => !t.active);

        if (txt == null)
        {
            txt = new FloatingText();
            txt.go = Instantiate(textPrefab);
            txt.go.transform.SetParent(textContainer.transform);
            txt.txt = txt.go.GetComponent<Text>();

            floatingTexts.Add(txt);
        }

        return txt;
    }
}
