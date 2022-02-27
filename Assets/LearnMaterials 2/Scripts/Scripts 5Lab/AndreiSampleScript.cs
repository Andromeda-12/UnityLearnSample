using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AndreiSampleScript : SampleScript
{
    private Transform myTransform;

    [SerializeField]
    [Min(1)]
    private float speed;

    [SerializeField]
    private Vector3 movingPoint;

    // Start is called before the first frame update
    void Start()
    {
        myTransform = transform;
    }

    [ContextMenu("Start")]
    public override void Use()
    {
        StartCoroutine(RotateCoroutine(movingPoint));
    }

    private IEnumerator RotateCoroutine(Vector3 target)
    {
        while (transform.position != target)
        {
            transform.position = Vector3.MoveTowards(transform.position, movingPoint, speed * Time.deltaTime);
            yield return null;
        }
        transform.position = target;
    }
}