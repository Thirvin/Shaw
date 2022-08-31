using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
public class Manager : MonoBehaviour
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
            temp.AddComponent<npc>();
            for(int i = 0;i < 7;i ++)
            {
                data[i] = Int32.Parse(subs[i]);
                Console.WriteLine(data[i]);
            }
            //write data
            temp.GetComponent<npc>().Hp = data[0];
            temp.GetComponent<npc>().Mana = data[1];
            temp.GetComponent<npc>().Speed = data[2];
            temp.GetComponent<npc>().Money = data[3];
            temp.GetComponent<npc>().Favorbility = data[4];
            temp.GetComponent<npc>().Career = data[5];
            temp.GetComponent<npc>().Personality = data[6];
            npcs.Add(temp);

            line = sr.ReadLine();
        }
    }

    public void leave()
    {
        StreamWriter sw = new StreamWriter("Assets/Character/data.txt");
        for(int i = 0;i < npcs.Count;i ++)
        {

            string temp = "";
            temp += (npcs[i].GetComponent<npc>().Hp.ToString() + "-" );
            temp += (npcs[i].GetComponent<npc>().Mana.ToString() + "-" );
            temp += (npcs[i].GetComponent<npc>().Speed.ToString() + "-" );
            temp += (npcs[i].GetComponent<npc>().Money.ToString() + "-" );
            temp += (npcs[i].GetComponent<npc>().Favorbility.ToString() + "-" );
            temp += (npcs[i].GetComponent<npc>().Career.ToString() + "-" );
            temp += (npcs[i].GetComponent<npc>().Personality.ToString());
            sw.WriteLine(temp);
            Destroy(npcs[i]);
        }
        npcs.Clear();
        sw.WriteLine("@");
        sw.Close();
    }

}
