using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockBullet : Bullet
{   
    public override void Start()
    {
        destroyDelayTime = 1;
        base.Start();
    }

    public override IEnumerator DestroyDelay()
    {
        return base.DestroyDelay();
    }
}
