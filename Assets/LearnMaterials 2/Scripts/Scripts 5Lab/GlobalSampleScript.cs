using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSampleScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject[] furnitures = GameObject.FindGameObjectsWithTag("Furniture");
        foreach(GameObject furniture in furnitures)
        {
            var script = furniture.GetComponent<SampleScript>();
            if(script != null)
                script.Use();
        }
    }
}
