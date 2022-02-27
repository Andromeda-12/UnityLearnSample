using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSampleScript : MonoBehaviour
{
    [ContextMenu("Start")]
    void Use()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");

        foreach(GameObject obj in objects)
        {
            var script = obj.GetComponent<SampleScript>();
            if(script != null)
                script.Use();
        }
    }
}
