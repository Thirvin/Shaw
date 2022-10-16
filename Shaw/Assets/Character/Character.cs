using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public int Max_Hp = 0, Max_Mana = 0;
    public int Money = 0;
    public int HP = 0, MP = 0;
    public CharacerStatus VIT = new CharacerStatus(5);
    public CharacerStatus MAN = new CharacerStatus(0);
    public float Speed = 0.0f;
    public List<GameObject> prefab = new List<GameObject>();

}
