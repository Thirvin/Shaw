using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPC : Character
{
    public string Name = "";
    public int Number = -1;
    public int Favorbility = 0;
    public int Career = 0;
    public int Personality = 0;
    public int WorkTime_Hour = 0,WorkTime_Min = 0;
    public int RestTime_Hour = 0,RestTime_Min = 0;
    public int Work_Place = 0,Rest_Place = 0;
    NavMeshAgent agent;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void MoveToDestination(Vector3 pos)
    {
        agent.SetDestination(pos);
        Debug.Log("Moving NPC: " + Name);
    }
    public void Trade(Player player)
    {
          //do things here
    }
    public void Talk(Player player)
    {
        Debug.Log("Talk");
        //do things here
    }

}
