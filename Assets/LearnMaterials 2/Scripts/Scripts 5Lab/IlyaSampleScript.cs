using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IlyaSampleScript : SampleScript
{
    [SerializeField]
    private Vector3 targetRotate;
    [Min(0)]
    [SerializeField]
    private float rotateSpeed;
    private Transform myTransform;
    private void Start()
    {
        myTransform = transform;
    }
    private Quaternion aasa;
    public void Update()
    {
        //transform.rotation = transform.rotation * Quaternion.Euler(new Vector3(1, 3, 0.5f) * rotateSpeed * Time.deltaTime);
    }
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
