using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectStats_Constant : MonoBehaviour
{
    public int change;
    public CharacerStatus modifier;
    public int effectStats_Constant()
    {
        Mod mod = new Mod(change,0);
        return 1;
    }
    public EffectStats_Constant(int change,CharacerStatus modifier)
    {
        this.change = change;
        this.modifier = modifier;

    }
}
