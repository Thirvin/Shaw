using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickEffectStats_Constant : Effect
{
    int change, time;
    CharacerStatus modifier;
    public int active()
    {
        time -= 1;
        modifier.AddModifier(new Mod(change,0));


        if(time == 0)
            return 1;
        else
            return 0;
    }
}
