using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Player : Character
{
    public int talent = 0, ex_career = 0, ex_habit = 0;
    public List<GameObject> npcs = new List<GameObject>();

    void Update()
    {
        //for test, W -> build, S -> leave
        if (Input.GetKeyDown (KeyCode.W))
        {
            this.GetComponent<NPCManager>().build();
        }
        if (Input.GetKeyDown (KeyCode.S))
        {
            this.GetComponent<NPCManager>().leave();
        }

    }
}
