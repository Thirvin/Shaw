using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSituationManager : MonoBehaviour
{
    public static WorldSituationManager Instance;

    [HeaderAttribute("Weather condition")]
    public bool sunnyDay = true;
    public bool rainyDay;

    [HeaderAttribute("If village been destroyed?")]
    public bool sampleVillage;

    [HeaderAttribute("If boss alive?")]
    public bool mathTeacher;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
