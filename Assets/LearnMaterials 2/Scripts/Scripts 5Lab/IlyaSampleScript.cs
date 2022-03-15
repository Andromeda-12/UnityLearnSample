using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlyaSampleScript : SampleScript
{
    private Transform myTransform;

    [SerializeField]
    private Vector3 targetRotate;

    [Min(0)]
    [SerializeField]
    private float rotateSpeed;

    private void Start()
    {
        myTransform = transform;
    }

    [ContextMenu("Start")]
    public override void Use()
    {
        StartCoroutine(RotateCoroutine(targetRotate));
    }

    private IEnumerator RotateCoroutine(Vector3 target)
    {
        var targetRotation = Quaternion.Euler(target);
        while (transform.rotation != targetRotation)
        {
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, Time.deltaTime * rotateSpeed);
            yield return null;
        }
        transform.rotation = targetRotation;
    }
}
