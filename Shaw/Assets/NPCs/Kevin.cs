using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Kevin : NPC
{
    private void Start()
    {
        hasMission = true;
    }

    //Remove or move base if you need
    public override void CustomSituationCheck(string file)
    {
        if (WorldSituationManager.Instance.rainyDay)
        {
            file_name += "RannyDay/";
            return;
        }
        
        base.CustomSituationCheck(file);
    }
}
