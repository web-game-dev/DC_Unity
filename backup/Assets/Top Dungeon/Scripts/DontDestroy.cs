using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{
    /* Adding this script to any scene Object
     * will make it so it doesn't get destroyed
     * upon loading a new scene
     */
     
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }
}
