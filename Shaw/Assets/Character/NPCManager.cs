using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class NPCManager : MonoBehaviour
{
    public GameObject characterPrefab;

    public List<GameObject> npcs = new List<GameObject>();

    public List<Transform> workPlaces = new List<Transform>();
    public List<Transform> restPlaces = new List<Transform>();

    private void Start()
    {
        TimeManager.Instance.npcManager = this;
    }
    public void TimeCheck()
    {
        foreach (GameObject npcObject in npcs)
        {
            NPC npc = npcObject.GetComponent<NPC>();

            //Rest first
            if (npc.WorkTime_Hour >= npc.RestTime_Hour && npc.WorkTime_Min > npc.RestTime_Min)
            {
                //Check if is in RestRime
                if((TimeManager.Instance.currentHour >= npc.RestTime_Hour && TimeManager.Instance.currentMin >= npc.RestTime_Min) 
                    && (TimeManager.Instance.currentHour <= npc.WorkTime_Hour && TimeManager.Instance.currentMin < npc.WorkTime_Min))
                {
                    if (npc.working) npc.working = false;
                    npc.MoveToDestination(restPlaces[npc.Rest_Place].position);
                    return;
                }
                else
                {
                    if (!npc.working) npc.working = true;
                    npc.MoveToDestination(workPlaces[npc.Work_Place].position);
                    return;
                }
            }

            //Work first
            if (npc.RestTime_Hour >= npc.WorkTime_Hour && npc.RestTime_Min > npc.WorkTime_Min)
            {
                //Check if is in WorkRime
                if ((TimeManager.Instance.currentHour >= npc.WorkTime_Hour && TimeManager.Instance.currentMin >= npc.WorkTime_Min)
                    && (TimeManager.Instance.currentHour <= npc.RestTime_Hour && TimeManager.Instance.currentMin < npc.RestTime_Min))
                {
                    if (!npc.working) npc.working = true;
                    npc.MoveToDestination(workPlaces[npc.Work_Place].position);
                    return;
                }
                else
                {
                    if (npc.working) npc.working = false;
                    npc.MoveToDestination(restPlaces[npc.Rest_Place].position);
                    return;
                }
            }


            /*
            if (TimeManager.Instance.currentHour == npcObject.GetComponent<NPC>().WorkTime_Hour && TimeManager.Instance.currentMin == npcObject.GetComponent<NPC>().WorkTime_Min)
            {
                npcObject.GetComponent<NPC>().MoveToDestination(workPlaces[npcObject.GetComponent<NPC>().Work_Place].position);
            }
            else if(TimeManager.Instance.currentHour == npcObject.GetComponent<NPC>().RestTime_Hour && TimeManager.Instance.currentMin == npcObject.GetComponent<NPC>().RestTime_Min)
            {
                npcObject.GetComponent<NPC>().MoveToDestination(restPlaces[npcObject.GetComponent<NPC>().Rest_Place].position);
            }
            */
        }
    }
    public void Build()
    {
        // summon the npc
        StreamReader sr = new StreamReader("Assets/Character/data.txt");
        string line;
        line = sr.ReadLine();

        while(line != "@")
        {
            //read data -> summon npc
            int[] data = new int [7] ;
            string[] subs = line.Split('-');

            GameObject npcTemp = Instantiate(characterPrefab);
            NPC npc = npcTemp.AddComponent<NPC>();

            for(int i = 0;i < 7;i ++)
            {
                data[i] = Int32.Parse(subs[i]);
                Console.WriteLine(data[i]);
            }

            //write data
            npc.Hp = data[0];
            npc.Mana = data[1];
            npc.Speed = data[2];
            npc.Money = data[3];
            npc.Favorbility = data[4];
            npc.Career = data[5];
            npc.Personality = data[6];
            npc.Number = npcs.Count;
            npc.Name = subs[7];
            string[] worktime = subs[8].Split(".");
            string[] resttime = subs[9].Split(".");

            npc.WorkTime_Hour = Int32.Parse(worktime[0]);
            npc.WorkTime_Min = Int32.Parse(worktime[1]);
            npc.RestTime_Hour = Int32.Parse(resttime[0]);
            npc.RestTime_Min = Int32.Parse(resttime[1]);

            npc.Work_Place = Int32.Parse(subs[10]);
            npc.Rest_Place = Int32.Parse(subs[11]);
            npcTemp.name = subs[7];
            //skin
            npcs.Add(npcTemp);

            line = sr.ReadLine();
        }
        sr.Close();

        Debug.Log("Complete building.");
    }

    public void Leave()
    {
        StreamWriter sw = new StreamWriter("Assets/Character/data.txt");
        for(int i = 0;i < npcs.Count;i ++)
        {
            NPC npc = npcs[i].GetComponent<NPC>();

            string npcTemp = "";
            npcTemp += (npc.Hp.ToString() + "-" );
            npcTemp += (npc.Mana.ToString() + "-" );
            npcTemp += (npc.Speed.ToString() + "-" );
            npcTemp += (npc.Money.ToString() + "-" );
            npcTemp += (npc.Favorbility.ToString() + "-" );
            npcTemp += (npc.Career.ToString() + "-" );
            npcTemp += (npc.Personality.ToString()+"-");
            npcTemp += (npc.Name+"-");
            npcTemp += (npc.RestTime_Hour.ToString()+"."+npc.RestTime_Min.ToString()+"-");
            npcTemp += (npc.WorkTime_Hour.ToString()+"."+npc.WorkTime_Min.ToString()+"-");
            npcTemp += (npc.Work_Place.ToString()+"-"+npc.Rest_Place.ToString());
            sw.WriteLine(npcTemp);
            Destroy(npcs[i]);
        }
        npcs.Clear();
        sw.WriteLine("@");
        sw.Close();

        Debug.Log("Complete leaving.");
    }

}
