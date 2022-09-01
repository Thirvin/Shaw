using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class Player : Character
{
    public int talent = 0, ex_career = 0, ex_habit = 0;
    public List<GameObject> npcs = new List<GameObject>();

    private void Awake()
    {
        GetComponent<NPCManager>().Build();
        Debug.Log("Test");
    }

    void Update()
    {
        //for NPC data test, W -> build, S -> leave
        if (Input.GetKeyDown (KeyCode.W))
        {
            GetComponent<NPCManager>().Build();
        }
        if (Input.GetKeyDown (KeyCode.S))
        {
            GetComponent<NPCManager>().Leave();
        }
    }
}
