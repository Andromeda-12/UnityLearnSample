using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSampleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Object");

        foreach(GameObject object in objects)
        {
            var script = furniture.GetComponent<SampleScript>();
            if(script != null)
                script.Use();
        }
    }
}
