using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocks : Weapon
{
    public GameObject rockBullet;
    public override void SpawnBullet()
    {
        base.SpawnBullet();
        Instantiate(rockBullet, transform.position, transform.rotation);
    }
}
