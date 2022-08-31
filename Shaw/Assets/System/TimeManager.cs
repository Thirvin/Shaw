using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    [HideInInspector]
    public NPCManager npcManager;

    float currentTime;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        StartCoroutine(TimeCounter());
    }

    IEnumerator TimeCounter()
    {
        yield return new WaitForSeconds(30f);
        //Time goes 10 min
        //Call NPCManager's time check function

        //Count again
        StartCoroutine(TimeCounter());
    }
}
