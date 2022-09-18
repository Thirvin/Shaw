using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.AI;
using static Cinemachine.DocumentationSortingAttribute;
using UnityEngine.SceneManagement;

public class NPC : Character
{
    public string Name = "";
    public int Number = -1;
    public int Favorbility = 0;
    public int Career = 0;
    public int Personality = 0;
    public int WorkTime_Hour = 0, WorkTime_Min = 0;
    public int RestTime_Hour = 0, RestTime_Min = 0;
    public int Work_Place = 0, Rest_Place = 0;

    public int HasCustomizedScripts;

    public bool working;
    NavMeshAgent agent;

    protected string file_name = "";

    public bool hasMission;

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
        Get_Diologue(player.level);
    }

    void Get_Diologue(int level)
    {
        NPC npc = this;
        file_name = "";

        file_name += npc.name + "/" + SceneManager.GetActiveScene().name + "/";

        CustomSituationCheck();

        file_name += level % 5 == 0 ? level / 5 - 1 : level / 5 + "/";
        file_name += npc.Favorbility % 10 == 0 ? npc.Favorbility / 10 - 1 : npc.Favorbility / 10 + "/";

        string allFile_name = file_name;
        allFile_name = allFile_name.Insert(0, "Assets/Resources/");

        DirectoryInfo di = new DirectoryInfo(allFile_name);
        FileInfo[] files = di.GetFiles("*.prefab");
        int fileCount = files.Length;
        System.Random crandom = new System.Random();
        file_name += crandom.Next(fileCount - 1);

        Instantiate(Resources.Load(file_name));
    }

    //Override this to customize;
    public virtual void CustomSituationCheck(
    {
        if (hasMission)
        {
            file_name += "Mission/";
        }
        else
        {
            file_name += "Chat/";
        }
    }

}
