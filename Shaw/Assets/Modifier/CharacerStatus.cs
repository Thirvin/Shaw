using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacerStatus
{
    public float B_value,E_value,F_value;
    public float magnifiction = 0;
    List<Mod> modifiers = new List<Mod>();

    public CharacerStatus(float value)
    {
        B_value = value;
        F_value = value;
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
        foreach(Mod mod in modifiers)
        {
            magnifiction += mod.magnifiction;
            E_value += mod.value;
        }
        F_value = (B_value+E_value)*(1+magnifiction);
    }
}
