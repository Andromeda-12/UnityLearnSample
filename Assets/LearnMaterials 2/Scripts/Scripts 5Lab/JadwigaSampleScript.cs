using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JadwigaSampleScript : SampleScript
{
    private Transform myTransform;

    [SerializeField]
    [Min(1)]
    private int count;

    [SerializeField]
    private float interval;

    [SerializeField]
    GameObject prefab;

    void Start()
    {
        myTransform = transform;
    }

    [ContextMenu("Start")]
    public override void Use()
    {
        Vector3 vector = new Vector3(myTransform.position.x, myTransform.position.y, myTransform.position.z);

        for (int i = 0; i < count; i++)
        {
            vector = new Vector3(vector.x, vector.y, vector.z + interval);
            Instantiate(prefab, vector, Quaternion.identity);
        }
    }
}
