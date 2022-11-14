using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingEffectGiver : MonoBehaviour
{
    public Effect effect;

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            PlayerManager.Instance.AddEffect(new EffectStats_Constant(5, PlayerManager.Instance.player.ATK));
        }
    }
}
