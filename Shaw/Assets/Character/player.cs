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
        //for NPC data test, W -> build, S -> leave
        if (Input.GetKeyDown (KeyCode.W))
        {
            this.GetComponent<NPCManager>().Build();
        }
        if (Input.GetKeyDown (KeyCode.S))
        {
            this.GetComponent<NPCManager>().Leave();
        }


        //for NPC time test
        if (Input.GetKeyDown(KeyCode.LeftBracket))
        {
            GetComponent<NPCManager>().WorkTime();
        }
        if (Input.GetKeyDown(KeyCode.RightBracket))
        {
            GetComponent<NPCManager>().RestTime();
        }
    }
}
