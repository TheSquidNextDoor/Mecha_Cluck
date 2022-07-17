using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemomeHelf : MonoBehaviour
{
    public int hitPoints; //How many hit points does this enemy have? Most mooks have 1.

    private Action<EnemomeHelf> death; //Death action for this enemy.

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //todo
    }
}
