using UnityEngine;
using UnityEngine.UI;

public class FloatingText
{
    /* This is the floating text data structure, along
     * with some of its behavior, coded in the functions below
     */

    [HideInInspector]
    public bool active;
    [HideInInspector]
    public GameObject go;
    [HideInInspector]
    public Text txt;
    [HideInInspector]
    public Vector3 motion;
    [HideInInspector]
    public float duration;
    [HideInInspector]
    public float lastShown;

    // Methods
    public void Show()
    {
        active = true;
        lastShown = Time.time;
        go.SetActive(active);
    }
    public void Hide()
    {
        active = false;
        go.SetActive(active);
    }
    public void UpdateFloatingText()
    {
        if (!active)
            return;

        if (Time.time - lastShown > duration)
            Hide();

        go.transform.position += motion * Time.deltaTime;
    }
}
