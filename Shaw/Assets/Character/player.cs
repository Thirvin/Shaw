using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class player : Character
{
    public int talent = 0,ex_career = 0,ex_habit = 0;
    public List<GameObject> npcs = new List<GameObject>();

    void Update()
    {

        if (Input.GetKeyDown (KeyCode.W))
        {
            this.GetComponent<Manager>().build();
        }
        if (Input.GetKeyDown (KeyCode.S))
        {
            this.GetComponent<Manager>().leave();
        }
    }
}
