using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crate : Fighter
{
    // Override
    protected override void Death()
    {
        Destroy(gameObject);
    }
}
