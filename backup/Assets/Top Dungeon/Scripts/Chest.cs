using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : Collectable
{
    public int pesosAmount = 5;  // Amount of pesos this chest will give out on collision, change in inspector
    public Sprite emptyChest;

    // Override
    protected override void OnCollect()
    {
        if (!collected)
        {
            collected = true;
            GetComponent<SpriteRenderer>().sprite = emptyChest;
            GameManager.instance.pesos += pesosAmount;
            GameManager.instance.ShowText("+" + pesosAmount + " pesos!", 25, Color.yellow, transform.position, Vector3.up * 25, 1.5f);
        }
    }
}
