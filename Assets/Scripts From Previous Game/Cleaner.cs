using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    public float destroytime;

    void Start()
    {
        Destroy(gameObject, destroytime);   
    }

    
}
