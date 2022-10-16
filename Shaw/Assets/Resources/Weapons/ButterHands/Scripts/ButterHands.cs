using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButterHands : Weapon
{
    public GameObject airBullet;    

    public override void SpawnBullet()
    {
        base.SpawnBullet();
        Instantiate(airBullet, transform.position, transform.rotation);
    }
}
