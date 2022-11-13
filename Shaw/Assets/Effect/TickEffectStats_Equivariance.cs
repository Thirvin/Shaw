using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickEffectStats_Equivariance : MonoBehaviour
{
    int change, time;
    CharacerStatus modifier;
    public int tickEffectStats_Constant()
    {
        time -= 1;
        EffectStats_Constant use_only_once = new EffectStats_Constant(change,modifier);
        use_only_once.effectStats_Constant();

        change -= 1;

        if(time == 0)
            return 1;
        else
            return 0;
    }
}
