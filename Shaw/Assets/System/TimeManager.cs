using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance;

    public int currentHour = 0,currentMin = 0;
    [HideInInspector]
    public NPCManager npcManager;


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
    private void Start()
    {
        StartCoroutine(TimeCounter());
    }

    IEnumerator TimeCounter()
    {
        yield return new WaitForSeconds(30f);
        //Time goes 10 min
        //Call NPCManager's time check function
        currentMin += 10;
        if(currentMin % 60 == 0)
        {
            currentHour += 1;
            if(currentHour %24 == 0)
                currentHour = 0;
            currentMin = 0;
        }
        npcManager.timeCheck();
        Debug.Log(currentHour.ToString()+":"+currentMin.ToString());

        //Count again
        StartCoroutine(TimeCounter());
    }
}
