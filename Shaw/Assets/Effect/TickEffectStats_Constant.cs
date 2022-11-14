using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickEffectStats_Constant : Effect
{
    int change, time;
    CharacerStatus modifier;
    public override bool active()
    {
        time -= 1;
        modifier.AddModifier(new Mod(change,0));


        if(time == 0)
            return true;
        else
            return false;
    }

    public TickEffectStats_Constant(int change, int time,CharacerStatus modifier)
    {
        this.change = change;
        this.time = time;
        this.modifier = modifier;
    }
}
