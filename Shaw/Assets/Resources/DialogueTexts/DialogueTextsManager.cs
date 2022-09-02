using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTextsManager : MonoBehaviour
{
    public string path;
    void Start()
    {
        var loadedObject = Resources.Load(path);
        Object texts = Instantiate(loadedObject, Vector3.zero, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
