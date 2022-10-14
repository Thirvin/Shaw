using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyManager : MonoBehaviour
{
    List<GameObject> enemys = new List<GameObject>();
    public void spawn(string id ,Vector3 pos)
    {
        GameObject temp = new GameObject();
        temp.AddComponent(Type.GetType(id));
        temp.transform.position = pos;
        enemys.Add(temp);
    }

}
