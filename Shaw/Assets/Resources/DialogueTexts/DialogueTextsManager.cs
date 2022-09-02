using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTextsManager : MonoBehaviour
{
    public string path;
    void Start()
    {
        var loadedObject = Resources.Load(path);
        Instantiate(loadedObject, Vector3.zero, Quaternion.identity);
    }
}
