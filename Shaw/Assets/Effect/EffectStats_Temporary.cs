using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStats_Temporary : Effect
{
    public int change, time;
    bool used = false;
    CharacerStatus modifier;
    public int active()
    {

        if(!used)
            used = true;
        else
        {
            time--;
            if(time == 0)
            {
                modifier.AddModifier(new Mod(-change,0));
                return 1;
            }
        }

        modifier.AddModifier(new Mod(change,0));

        return 0;
    }
}
