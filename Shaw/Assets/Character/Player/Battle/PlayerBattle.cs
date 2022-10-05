using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBattle : MonoBehaviour
{
    Player player;
    private void Start()
    {
        player = gameObject.GetComponent<Player>();
        player.attack += Attack;
    }
    private void Attack()
    {
        Item shoot = GetComponent(Type.GetType(player.Weapon_Id)) as Item;
        shoot.Shoot();
    }
    private void Hurt()
    {
        //do thing with playmanager
    }
}
