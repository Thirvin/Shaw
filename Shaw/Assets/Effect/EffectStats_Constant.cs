using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStats_Constant : Effect
{
    public int change;
    public CharacerStatus modifier;
    public override bool active()
    {
        Mod mod = new Mod(change,0);
        return true;
    }
    public EffectStats_Constant(int change, CharacerStatus modifier)
    {
        this.change = change;
        this.modifier = modifier;

    }
}
