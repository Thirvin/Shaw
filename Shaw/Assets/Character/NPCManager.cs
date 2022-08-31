using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class NPCManager : MonoBehaviour
{

    public List<GameObject> npcs = new List<GameObject>();

    public void build()
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

            GameObject temp = new GameObject();
            NPC npc = temp.AddComponent<NPC>();

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
            //skin
            npcs.Add(temp);

            line = sr.ReadLine();
        }
        sr.Close();

        Debug.Log("Complete building.");
    }

    public void leave()
    {
        StreamWriter sw = new StreamWriter("Assets/Character/data.txt");
        for(int i = 0;i < npcs.Count;i ++)
        {
            NPC npc = npcs[i].GetComponent<NPC>();

            string temp = "";
            temp += (npc.Hp.ToString() + "-" );
            temp += (npc.Mana.ToString() + "-" );
            temp += (npc.Speed.ToString() + "-" );
            temp += (npc.Money.ToString() + "-" );
            temp += (npc.Favorbility.ToString() + "-" );
            temp += (npc.Career.ToString() + "-" );
            temp += (npc.Personality.ToString()+"-");
            temp += (npc.Name);
            sw.WriteLine(temp);
            Destroy(npcs[i]);
        }
        npcs.Clear();
        sw.WriteLine("@");
        sw.Close();

        Debug.Log("Complete leaving.");
    }

}
