using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacerStatus
{
    public float F_value;
    float B_value, E_value;
    float magnifiction = 0;
    List<Mod> modifiers = new List<Mod>();

    public CharacerStatus(float baseValue)
    {
        B_value = baseValue;
        F_value = baseValue;
    }
    public void AddModifier(Mod mod)
    {
        modifiers.Add(mod);
        Refresh();
    }
    public void RemoveModifier(Mod mod)
    {
        Mod temp = modifiers.Find(Mod => (Mod.value == mod.value && Mod.magnifiction == mod.magnifiction));
        Debug.Log(modifiers.Remove(temp));        
        Refresh();
    }
    public void Refresh()
    {
        magnifiction = 0;
        F_value = 0;
        E_value = 0;
        foreach(Mod mod in modifiers)
        {
            magnifiction += mod.magnifiction;
            E_value += mod.value;
        }
        F_value = (B_value + E_value) * (1 + magnifiction);
        Debug.Log("R");
    }
}
