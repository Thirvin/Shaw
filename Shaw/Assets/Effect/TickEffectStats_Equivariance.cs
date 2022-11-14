using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TickEffectStats_Equivariance : Effect
{
    int change, time;
    CharacerStatus modifier;
    public override bool active()
    {
        time -= 1;
        modifier.AddModifier(new Mod(change,0));

        change -= 1;

        if(time == 0)
            return true;
        else
            return false;
    }
    public TickEffectStats_Equivariance(int change, int time,CharacerStatus modifier)
    {
        this.change = change;
        this.time = time;
        this.modifier = modifier;
    }
}
