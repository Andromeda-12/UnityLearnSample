using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JadwigaSampleScript : SampleScript
{
    [SerializeField]
    [Min(1)]
    private int count;

    [SerializeField]
    private float interval;

    [SerializeField]
    GameObject prefab;

    [ContextMenu("Start")]
    public override void Use()
    {
        Vector3 vector = new Vector3(transform.position.x, transform.position.y, transform.position.z);

        for (int i = 0; i < count; i++)
        {
            vector = new Vector3(vector.x, vector.y, vector.z + interval);
            Instantiate(prefab, vector, Quaternion.identity);
        }
    }
}
