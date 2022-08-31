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

    NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void MoveToDestination(Vector3 pos)
    {
        agent.SetDestination(pos);
        Debug.Log("Moving NPC: " + Name);
    }
    void Trade(GameObject player)
    {
          //do things here
    }
    void Talk(GameObject player)
    {

        //do things here
    }

}
