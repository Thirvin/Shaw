using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirBullet : Bullet
{
    public override void Start()
    {
        base.Start();
        destroyDelayTime = 0.1f;
    }
}
