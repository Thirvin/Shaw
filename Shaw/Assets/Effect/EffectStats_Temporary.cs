using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStats_Temporary : Effect
{
    public int change, time;
    bool used = false;
    CharacerStatus modifier;
    public EffectStats_Temporary(int change,int time,CharacerStatus modifier)
    {
        this.change = change;
        this.time = time;
        this.modifier = modifier;
    }
    public override bool active()
    {

        if(!used)
            used = true;
        else
        {
            time--;
            if(time == 0)
            {
                modifier.AddModifier(new Mod(-change,0));
                return true;
            }
        }

        modifier.AddModifier(new Mod(change,0));

        return false;
    }
}
